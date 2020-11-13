namespace Awoo.Core.Roles
{
    public record Witch : Villager
    {
        public bool UsedSaveAction { get; init; } = false;
        public bool UsedKillAction { get; init; } = false;
        public string KillActionTarget { get; init; } = null;

        public override string ToString() => "Witch";
    }
}