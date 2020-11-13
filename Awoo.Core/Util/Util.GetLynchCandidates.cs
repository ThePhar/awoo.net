using Awoo.Core.Enums;
using Awoo.Core.Records;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Awoo.Core.Util
{
    public static partial class Util
    {
        /// <summary>
        /// Collects a running total of every Accusation each player has made and returns a list of Identifiers that
        /// have the most votes to be lynched. Returns an empty list if no votes were made or most of the votes were to
        /// not lynch any players.
        /// </summary>
        /// <param name="gameState">The gameState to check for lynch votes in.</param>
        /// <returns>A list of player Identifiers with the most votes to be lynched.</returns>
        public static ImmutableArray<string> GetLynchCandidates(this GameState gameState)
        {
            // Keep a running total of players who vote to not lynch players.
            var noLynchVotes = 0;
            
            // Keep track of players with the most votes.
            var highestLynchVoteCount = -1;
            var potentialLynchCandidates = new List<string>();
            var allLynchCounts = new Dictionary<string, int>();
            
            // Check every player's Accusation property and get a running total of everyone's votes.
            foreach (var player in gameState.Players.Values)
            {
                // Do not count eliminated player's votes.
                if (!player.Alive) continue;
                
                // Break down votes by vote type.
                switch (player.Accusation.Type)
                {
                    case VoteType.Lynch:
                        // Get the accused player.
                        var accused = player.Accusation.Identifier;
                        
                        // If player is already being tracked in lynchVotes, add to it, otherwise add it to dictionary.
                        if (allLynchCounts.ContainsKey(accused))
                            allLynchCounts[accused] += player.Role.VotePower;
                        else
                            allLynchCounts.Add(accused, player.Role.VotePower);
                        
                        // Get the new count for this player.
                        var accusedTally = allLynchCounts[accused];
                        
                        // Check if this player has the most votes and reset who we're tracking.
                        if (accusedTally > highestLynchVoteCount)
                        {
                            highestLynchVoteCount = accusedTally;
                            potentialLynchCandidates = new List<string>() { accused };
                        }
                        else if (accusedTally == highestLynchVoteCount)
                        {
                            potentialLynchCandidates.Add(accused);
                        }

                        continue;

                    case VoteType.NoLynch:
                        noLynchVotes += player.Role.VotePower;
                        continue;
                    
                    default:
                        continue;
                }
            }
            
            // Return an empty list if we have same or more No Lynch votes than the next highest vote for a player.
            return (noLynchVotes >= highestLynchVoteCount) 
                ? ImmutableArray<string>.Empty 
                : potentialLynchCandidates.ToImmutableArray();
        }
    }
}