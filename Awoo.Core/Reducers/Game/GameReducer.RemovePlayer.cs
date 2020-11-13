using Awoo.Core.Actions.Game;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        private static GameState RemovePlayer(GameState game, RemovePlayerAction action)
        {
            return game with { Players = game.Players.Remove(action.Identifier) };
        }
    }
}