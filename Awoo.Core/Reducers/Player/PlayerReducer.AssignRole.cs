using Awoo.Core.Actions.Player;
using Awoo.Core.Records;

namespace Awoo.Core.Reducers.Player
{
    public static partial class PlayerReducer
    {
        private static GameState AssignRole(GameState game, AssignRoleAction action)
        {
            // Attempt to get this player object, otherwise return our original state.
            if (!game.Players.TryGetValue(action.Identifier, out var player)) 
                return game;

            return game with
            {
                Players = game.Players.SetItem(
                    action.Identifier,
                    player with { Role = action.RoleToAssign }
                )
            };
        }
    }
}