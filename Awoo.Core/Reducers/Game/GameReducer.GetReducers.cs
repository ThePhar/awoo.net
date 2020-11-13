using Awoo.Core.Actions.Game;
using Awoo.Core.Records;
using ReduxSimple;
using System.Collections.Generic;

using static ReduxSimple.Reducers;

namespace Awoo.Core.Reducers.Game
{
    public static partial class GameReducer
    {
        public static IEnumerable<On<GameState>> GetReducers()
        {
            return new List<On<GameState>>
            {
                On<SetIdentifierAction, GameState>(SetIdentifier),
                On<AddPlayerAction, GameState>(AddPlayer),
                On<RemovePlayerAction, GameState>(RemovePlayer),
                On<SetDayAction, GameState>(SetDay),
                On<SetNightAction, GameState>(SetNight),
                On<EndGameAction, GameState>(EndGame)
            };
        }
    }
}