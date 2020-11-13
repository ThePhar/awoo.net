using Awoo.Core.Enums;
using Awoo.Core.Roles;

namespace Awoo.Core.Records
{
    public record PlayerState
    {
        public string Identifier { get; init; } = string.Empty;
        public Vote Accusation { get; init; } = Vote.None;
        public Villager Role { get; init; } = new Villager();
        public EliminationCause? CauseOfDeath { get; init; } = null;

        /// <summary>
        /// Returns true if no cause of death is set.
        /// </summary>
        public bool Alive => CauseOfDeath == null;
    }
}