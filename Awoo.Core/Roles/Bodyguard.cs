namespace Awoo.Core.Roles
{
    public record Bodyguard : Villager
    {
        public string Protecting { get; init; } = null;
        public string LastProtected { get; init; } = null;

        public override string ToString() => "Bodyguard";
    }
}