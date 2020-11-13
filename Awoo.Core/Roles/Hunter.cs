namespace Awoo.Core.Roles
{
    public record Hunter : Villager
    {
        public string Target { get; init; } = null;

        public override string ToString() => "Hunter";
    }
}