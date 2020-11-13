namespace Awoo.Core.Roles
{
    public record Mayor : Villager
    {
        public override int VotePower { get; init; } = 2;

        public override string ToString() => "Mayor";
    }
}