using System.Collections.Generic;
using System.Collections.Immutable;
using Awoo.Core.Enums;
using Awoo.Core.Records;
using Awoo.Core.Util;
using Xunit;

namespace Awoo.Core.Tests.Util
{
    public class GetLynchVotesTests
    {
        [Fact]
        public void ReturnsListOfOnePlayerWithMostLynchVotes()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.Lynch("4") }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.Lynch("4") }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.Lynch("4") }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.None }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.Lynch("4") }},
                {"6", new PlayerState() { Identifier = "6", Accusation = Vote.None }},
                {"7", new PlayerState() { Identifier = "7", Accusation = Vote.Lynch("3") }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.Lynch("4") }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Single(lynchVotes);
            Assert.Contains("4", lynchVotes);
        }
        
        [Fact]
        public void ReturnsListOfMultiplePlayersTiedWithMostLynchVotes()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.Lynch("4") }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.Lynch("4") }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.Lynch("2") }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.None }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.Lynch("2") }},
                {"6", new PlayerState() { Identifier = "6", Accusation = Vote.None }},
                {"7", new PlayerState() { Identifier = "7", Accusation = Vote.Lynch("4") }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.Lynch("2") }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Equal(2, lynchVotes.Length);
            Assert.Contains("4", lynchVotes);
            Assert.Contains("2", lynchVotes);
        }
        
        [Fact]
        public void ReturnsListOfNoPlayersIfMoreNoLynchVotesThanLynchVotes()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.Lynch("4") }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.Lynch("4") }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.Lynch("4") }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.NoLynch }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.NoLynch }},
                {"6", new PlayerState() { Identifier = "6", Accusation = Vote.NoLynch }},
                {"7", new PlayerState() { Identifier = "7", Accusation = Vote.NoLynch }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.Lynch("2") }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Empty(lynchVotes);
        }
        
        [Fact]
        public void ReturnsListOfNoPlayersIfTiedWithHighestLynchVotes()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.Lynch("4") }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.Lynch("4") }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.Lynch("4") }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.None }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.NoLynch }},
                {"6", new PlayerState() { Identifier = "6", Accusation = Vote.NoLynch }},
                {"7", new PlayerState() { Identifier = "7", Accusation = Vote.NoLynch }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.Lynch("2") }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Empty(lynchVotes);
        }
        
        [Fact]
        public void ReturnsListOfNoPlayersIfNoPlayersVoted()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.None }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.None }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.None }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.None }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.None }},
                {"6", new PlayerState() { Identifier = "6", Accusation = Vote.None }},
                {"7", new PlayerState() { Identifier = "7", Accusation = Vote.None }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.None }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Empty(lynchVotes);
        }

        [Fact]
        public void ReturnsListOfPlayersIgnoringEliminatedPlayerVotes()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1", Accusation = Vote.Lynch("5") }},
                {"2", new PlayerState() { Identifier = "2", Accusation = Vote.Lynch("5") }},
                {"3", new PlayerState() { Identifier = "3", Accusation = Vote.Lynch("5") }},
                {"4", new PlayerState() { Identifier = "4", Accusation = Vote.Lynch("2") }},
                {"5", new PlayerState() { Identifier = "5", Accusation = Vote.Lynch("2") }},
                {"6", new PlayerState() 
                    { Identifier = "6", Accusation = Vote.Lynch("2"), CauseOfDeath = EliminationCause.Werewolves }},
                {"7", new PlayerState() 
                    { Identifier = "7", Accusation = Vote.Lynch("2"), CauseOfDeath = EliminationCause.Werewolves }},
                {"8", new PlayerState() { Identifier = "8", Accusation = Vote.None }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our most lynch votes.
            var lynchVotes = game.GetLynchCandidates();
            
            // Expectations
            Assert.Single(lynchVotes);
            Assert.Contains("5", lynchVotes);
        }
    }
}