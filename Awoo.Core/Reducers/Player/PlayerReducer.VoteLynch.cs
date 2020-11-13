using Awoo.Core.Actions.Player;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Player
{
    public static partial class PlayerReducer
    {
        private static GameState VoteLynch(GameState game, VoteLynchAction action)
        {
            // Attempt to get this player object, otherwise return our original state.
            if (!game.Players.TryGetValue(action.Identifier, out var player)) 
                return game;

            return game with
            {
                Players = game.Players.SetItem(
                    action.Identifier,
                    player with { Accusation = Vote.Lynch(action.Identifier) }
                )
            };
        }
    }
}