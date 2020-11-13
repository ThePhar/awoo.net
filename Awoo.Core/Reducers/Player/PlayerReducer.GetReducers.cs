using Awoo.Core.Actions.Player;
using Awoo.Core.Records;
using ReduxSimple;
using System.Collections.Generic;

using static ReduxSimple.Reducers;

namespace Awoo.Core.Reducers.Player
{
    public static partial class PlayerReducer
    {
        public static IEnumerable<On<GameState>> GetReducers()
        {
            return new List<On<GameState>>
            {
                On<EliminateAction, GameState>(Eliminate),
                On<ClearVoteAction, GameState>(ClearVote),
                On<VoteLynchAction, GameState>(VoteLynch),
                On<VoteNoLynchAction, GameState>(VoteNoLynch),
                On<AssignRoleAction, GameState>(AssignRole)
            };
        }
    }
}