using System;
using System.Collections.Generic;

namespace HackerRank_InterviewPreparation
{
    public class Challenges
    {
        public static int ActivityNotifications(List<int> expenditure, int d)
        {
            if (expenditure.Count <= d)
                return 0;

            var trailing = expenditure.GetRange(0, d);
            var notificationsCount = 0;

            for (int i = d; i < expenditure.Count; i++)
            {
                // check if expediture at the given day is 2x or more than median of trailing days
                var median = GetMedian1(trailing);
                if (expenditure[i] >= median * 2)
                    notificationsCount++;

                // update traling
                trailing.Add(expenditure[i]);
                trailing.RemoveAt(0);
            }

            return notificationsCount;

        }
        private static decimal GetMedian1(List<int> trailing)
        {
            trailing.Sort();
            // Check if has even or odd number of elements
            if (trailing.Count % 2 == 0)
                // Even number - calc average of two middle elements
                return ((decimal)trailing[trailing.Count / 2] + trailing[trailing.Count / 2 - 1]) / 2;
            else
                return (trailing[trailing.Count / 2]);
        }
    }
}
