using Awoo.Core.Enums;

namespace Awoo.Core.Actions.Player
{
    public record VoteLynchAction
    {
        public string Identifier { get; init; }
        public string Accusing { get; init; }

        public override string ToString() 
            => base.ToString() + $"\n\t{{ Identifier: {Identifier}, Accusing: {Accusing} }}";
    }
}