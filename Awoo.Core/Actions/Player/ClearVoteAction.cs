using Awoo.Core.Enums;

namespace Awoo.Core.Actions.Player
{
    public record ClearVoteAction
    {
        public string Identifier { get; init; }

        public override string ToString() => base.ToString() + $"\n\t{{ Identifier: {Identifier} }}";
    }
}