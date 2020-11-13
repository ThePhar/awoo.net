using System;
using Awoo.Core.Records;
using Awoo.Core.Roles;
using System.Collections.Immutable;
using System.Linq;

namespace Awoo.Core.Util
{
    public static partial class Util
    {
        /// <summary>
        /// Gets a list of all werewolf players' Identifiers that are currently not eliminated.
        /// </summary>
        /// <param name="gameState">The gameState to check for werewolves in.</param>
        /// <returns>A list of player Identifiers that are werewolves.</returns>
        public static ImmutableArray<Tuple<string, Werewolf>> GetWerewolves(this GameState gameState)
        {
            return gameState.Players.Values
                .Where(player => player.Role is Werewolf)
                .Where(player => player.Alive)
                .Select(player => new Tuple<string, Werewolf>(player.Identifier, player.Role as Werewolf))
                .ToImmutableArray();
        }
    }
}