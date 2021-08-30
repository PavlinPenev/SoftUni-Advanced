using System;

namespace DateMod
{
    public static class DateModifier
    {
        
        public static double GetDifferenceOfDates(DateTime date1, DateTime date2)
        {
            int compareDates = date1.CompareTo(date2);        //Less than zero This instance is earlier than value.
                                                              //Zero This instance is the same as value.
                                                              //Greater than zero This instance is later than value.
            if (compareDates == -1)
            {
                return (date2 - date1).TotalDays;
            }

            if (compareDates == 1)
            {
                return (date1 - date2).TotalDays;
            }

            return 0;
        }
    }
}
