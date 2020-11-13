using Awoo.Core.Actions.Game;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        private static GameState AddPlayer(GameState game, AddPlayerAction action)
        {
            // Do not add players if identifier is empty.
            if (action.Identifier == "")
                return game;

            return game with { 
                Players = game.Players.SetItem(
                    action.Identifier, 
                    new PlayerState() { Identifier = action.Identifier }
                ) 
            };
        }
    }
}