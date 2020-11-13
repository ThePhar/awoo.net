using Awoo.Core.Enums;

namespace Awoo.Core.Actions.Player
{
    public record EliminateAction
    {
        public string Identifier { get; init; }
        public EliminationCause Reason { get; init; }

        public override string ToString() => 
            base.ToString() + $"\n\t{{ Identifier: {Identifier}, Reason: {Reason} }}";
    }
}