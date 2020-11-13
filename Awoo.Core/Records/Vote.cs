using Awoo.Core.Enums;

namespace Awoo.Core.Records
{
    public class Vote
    {
        public readonly string Identifier;
        public readonly VoteType Type;

        private Vote(VoteType type, string identifier = "")
        {
            Identifier = identifier;
            Type = type;
        }

        public static Vote None    => new Vote(VoteType.None);
        public static Vote NoLynch => new Vote(VoteType.NoLynch);
        
        /// <summary>
        /// Creates a Lynch-type Vote object with a reference to another player's identifier.
        /// </summary>
        /// <param name="identifier">The Identifier string of the player to vote to lynch.</param>
        /// <returns>A lynch-type vote object with reference to another player.</returns>
        public static Vote Lynch(string identifier) => new Vote(VoteType.Lynch, identifier);
    }
}