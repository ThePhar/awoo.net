using Awoo.Core.Enums;
using System.Collections.Immutable;

namespace Awoo.Core.Records
{
    public record GameState
    {
        public string Identifier { get; init; } = string.Empty;
        public uint Day { get; init; } = 0;
        public Phase Phase { get; init; } = Phase.Pregame;
        public ImmutableDictionary<string, PlayerState> Players { get; init; } = ImmutableDictionary<string, PlayerState>.Empty;
    }
}