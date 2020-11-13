using System.Collections.Generic;
using Awoo.Core.Enums;
using Awoo.Core.Records;
using System.Collections.Immutable;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        private static GameState SetNight(GameState game)
        {
            // Clear votes from all players.
            var players = new Dictionary<string, PlayerState>();
            foreach (var player in game.Players.Values)
            {
                players.Add(player.Identifier, player with { Accusation = Vote.None });
            }

            return game with
            {
                Day = game.Day + 1, 
                Phase = Phase.Night,
                Players = players.ToImmutableDictionary()
            };
        }
    }
}