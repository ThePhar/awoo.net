using Awoo.Core.Enums;

namespace Awoo.Core.Roles
{
    public record Werewolf : Villager
    {
        public override Appearance Appearance { get; init; } = Appearance.Werewolf;
        public override Team Team { get; init;  } = Team.Werewolves;

        public string Target { get; init; } = null;

        public override string ToString() => "Werewolf";
    }
}