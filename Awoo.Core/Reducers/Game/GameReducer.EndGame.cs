using Awoo.Core.Enums;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        private static GameState EndGame(GameState game)
        {
            return game with { Phase = Phase.Endgame };
        }
    }
}