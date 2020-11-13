using System;
using Awoo.Core.Enums;
using Awoo.Core.Records;
using System.Collections.Generic;
using System.Collections.Immutable;
using Awoo.Core.Roles;

namespace Awoo.Core.Util
{
    public static partial class Util
    {
        /// <summary>
        /// Collects a running total of werewolf Target each player has made and returns a list of Identifiers that have
        /// the most votes to be targeted. Returns an empty list if no targets are made.
        /// </summary>
        /// <param name="gameState">The gameState to check for werewolf targets in.</param>
        /// <returns>A list of player Identifiers with the most werewolves targeting them.</returns>
        public static ImmutableArray<string> GetWerewolfTargetCandidates(this GameState gameState)
        {
            // Keep track of players with the most votes.
            var highestCount = -1;
            var potentialTargets = new List<string>();
            var allTargets = new Dictionary<string, int>();
            
            // Check every player's Accusation property and get a running total of everyone's votes.
            foreach (var (_, werewolf) in gameState.GetWerewolves())
            {
                var target = werewolf.Target;
                
                // If werewolf didn't target, ignore it.
                if (target == null) continue;
                
                // If player is already being tracked in allTargets, add to it, otherwise add it to dictionary.
                if (allTargets.ContainsKey(target))
                    allTargets[target] += 1;
                else
                    allTargets.Add(target, 1);
                
                // Get the new count for this target.
                var targetTally = allTargets[target];
                        
                // Check if this player has the most votes and reset who we're tracking.
                if (targetTally > highestCount)
                {
                    highestCount = targetTally;
                    potentialTargets = new List<string>() { target };
                }
                else if (targetTally == highestCount)
                {
                    potentialTargets.Add(target);
                }
            }
            
            // Return our targets.
            return potentialTargets.ToImmutableArray();
        }
    }
}