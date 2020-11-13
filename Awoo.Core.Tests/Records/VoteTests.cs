using Awoo.Core.Enums;
using Awoo.Core.Records;
using Xunit;

// ReSharper disable xUnit2000
namespace Awoo.Core.Tests.Records
{
    public class VoteTests
    {
        [Fact]
        public void CreatesValidNoneVoteObject()
        {
            var vote = Vote.None;
            
            Assert.Equal(VoteType.None, vote.Type);
        }
        
        [Fact]
        public void CreatesValidNoLynchVoteObject()
        {
            var vote = Vote.NoLynch;
            
            Assert.Equal(VoteType.NoLynch, vote.Type);
        }
        
        [Fact]
        public void CreatesValidLynchVoteObject()
        {
            const string id = "123456";
            var vote = Vote.Lynch(id);
            
            Assert.Equal(VoteType.Lynch, vote.Type);
            Assert.Equal(id, vote.Identifier);
        }
    }
}