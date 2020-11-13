using Awoo.Core.Roles;

namespace Awoo.Core.Actions.Player
{
    public record AssignRoleAction
    {
        public string Identifier { get; init; }
        public Villager RoleToAssign { get; init; }

        public override string ToString() => 
            base.ToString() + $"\n\t{{ Identifier: {Identifier}, Role: {RoleToAssign} }}";
    }
}