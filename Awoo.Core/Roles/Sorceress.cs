using System;
using Awoo.Core.Enums;

namespace Awoo.Core.Roles
{
    public record Sorceress : Villager
    {
        public override Team Team { get; init; } = Team.Werewolves;

        public string Inspecting { get; init; } = null;
        public Tuple<string, uint, bool> InspectionHistory { get; init; } = null;

        public override string ToString() => "Sorceress";
    }
}