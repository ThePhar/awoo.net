using Awoo.Core.Enums;

namespace Awoo.Core.Roles
{
    public record Lycan : Villager
    {
        public override Appearance Appearance { get; init; } = Appearance.Werewolf;

        public override string ToString() => "Lycan";
    }
}