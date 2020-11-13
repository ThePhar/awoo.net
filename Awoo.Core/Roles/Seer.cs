using System;
using Awoo.Core.Enums;

namespace Awoo.Core.Roles
{
    public record Seer : Villager
    {
        public string Inspecting { get; init; } = null;
        public Tuple<string, uint, Appearance> InspectionHistory { get; init; } = null;

        public override string ToString() => "Seer";
    }
}