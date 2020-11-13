using Awoo.Core.Enums;

namespace Awoo.Core.Roles
{
    public record Villager
    {
        public virtual Appearance Appearance { get; init; } = Appearance.Villager;
        public virtual Team Team { get; init; } = Team.Villagers;

        public virtual int VotePower { get; init; } = 1;

        public override string ToString() => "Villager";
    }
}