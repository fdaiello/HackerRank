using System.Collections.Generic;
using HackerRank_InterviewPreparation;
using Xunit;

namespace HackerRank_InterviewPreparation.Test
{
    public class ChallengesTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void activityNotifications_Test(List<int> expenditure, int d, int expected)
        {
            // Arrange

            // Act
            var result = Challenges.ActivityNotifications(expenditure, d);

            // Assert
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {
                    new List<int>{2, 3, 4, 2, 3, 6, 8, 4, 5 },
                    5,
                    2
                },
                new object[] {
                    new List<int>{1, 2, 3, 4, 4  },
                    4,
                    0
                },
            };
    }
}
