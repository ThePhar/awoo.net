using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Awoo.Core.Enums;
using Awoo.Core.Records;
using Awoo.Core.Roles;
using Awoo.Core.Util;
using Xunit;

namespace Awoo.Core.Tests.Util
{
    public class GetWerewolvesTests
    {
        [Fact]
        public void ReturnsListOfWerewolves()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1" }},
                {"2", new PlayerState() { Identifier = "2", Role = new Werewolf() }},
                {"3", new PlayerState() { Identifier = "3" }},
                {"4", new PlayerState() { Identifier = "4" }},
                {"5", new PlayerState() { Identifier = "5", Role = new Werewolf() }},
                {"6", new PlayerState() { Identifier = "6" }},
                {"7", new PlayerState() { Identifier = "7" }},
                {"8", new PlayerState() { Identifier = "8" }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our werewolves.
            var werewolves = game.GetWerewolves();
            
            // Expectations
            Assert.Equal(2, werewolves.Length);
        }
        
        [Fact]
        public void ReturnsListOfWerewolvesIgnoringEliminatedWerewolves()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1" }},
                {"2", new PlayerState() { Identifier = "2", Role = new Werewolf() }},
                {"3", new PlayerState() { Identifier = "3" }},
                {"4", new PlayerState() { Identifier = "4" }},
                {"5", new PlayerState() 
                    { Identifier = "5", Role = new Werewolf(), CauseOfDeath = EliminationCause.Lynching }},
                {"6", new PlayerState() { Identifier = "6" }},
                {"7", new PlayerState() { Identifier = "7" }},
                {"8", new PlayerState() { Identifier = "8" }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our werewolves.
            var werewolves = game.GetWerewolves();
            
            // Expectations
            Assert.Single(werewolves);
        }
        
        [Fact]
        public void ReturnsListOfWerewolvesIncludingSpecializedWerewolves()
        {
            // Create our list of players.
            var players = new Dictionary<string, PlayerState>()
            {
                {"1", new PlayerState() { Identifier = "1" }},
                {"2", new PlayerState() { Identifier = "2", Role = new Werewolf() }},
                {"3", new PlayerState() { Identifier = "3" }},
                {"4", new PlayerState() { Identifier = "4" }},
                {"5", new PlayerState() { Identifier = "5", Role = new AlphaWerewolf() }},
                {"6", new PlayerState() { Identifier = "6" }},
                {"7", new PlayerState() { Identifier = "7" }},
                {"8", new PlayerState() { Identifier = "8" }},
            };
            
            // Generate our game.
            var game = new GameState() { Players = players.ToImmutableDictionary() };
            
            // Get our werewolves.
            var werewolves = game.GetWerewolves();
            
            // Expectations
            Assert.Equal(2, werewolves.Length);
        }
    }
}