using Awoo.Core.Records;
using Awoo.Core.Reducers.Game;
using Awoo.Core.Reducers.Player;
using ReduxSimple;
using System.Collections.Generic;

using static ReduxSimple.Reducers;

namespace Awoo.Core.Reducers
{
    public static class RootReducer
    {
        public static IEnumerable<On<GameState>> CreateReducers()
        {
            return CombineReducers(
                GameReducer.GetReducers(),
                PlayerReducer.GetReducers()
            );
        }
    }
}