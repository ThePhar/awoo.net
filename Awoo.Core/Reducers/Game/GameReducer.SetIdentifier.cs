using Awoo.Core.Actions.Game;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        private static GameState SetIdentifier(GameState game, SetIdentifierAction action)
        {
            return game with { Identifier = action.Identifier };
        }
    }
}