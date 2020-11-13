namespace Awoo.Core.Actions.Game
{
    public record RemovePlayerAction
    {
        public string Identifier { get; init; }
        
        public override string ToString() => base.ToString() + $"\n\t{{ Identifier: {Identifier} }}";
    }
}