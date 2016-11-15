using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    public static class TimeDate
    {
        #region Enums
        /// <summary>
        /// Enums of quarter
        /// </summary>
        public enum Quarter { First = 1, Second = 2, Third = 3, Fourth = 4 }

        /// <summary>
        /// Enums of month
        /// </summary>
        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
        #endregion

        #region Quarters
        /// <summary>
        /// Get start of quarter
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="qtr">quater</param>
        /// <returns>date first of quarter</returns>
        public static DateTime GetStartOfQuarter(int year, Quarter qtr)
        {
            if (qtr == Quarter.First) // 1st Quarter = January 1 to March 31
                return new DateTime(year, 1, 1, 0, 0, 0, 0);

            else if (qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(year, 4, 1, 0, 0, 0, 0);

            else if (qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(year, 7, 1, 0, 0, 0, 0);

            else // 4th Quarter = October 1 to December 31
                return new DateTime(year, 10, 1, 0, 0, 0, 0);
        }


        /// <summary>
        /// Get end of quarter
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="qtr">quater</param>
        /// <returns>date end of quarter</returns>
        public static DateTime GetEndOfQuarter(int year, Quarter qtr)
        {
            if (qtr == Quarter.First) // 1st Quarter = January 1 to March 31
                return new DateTime(year, 3, DateTime.DaysInMonth(year, 3), 23, 59, 59, 999);

            else if (qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(year, 6, DateTime.DaysInMonth(year, 6), 23, 59, 59, 999);

            else if (qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(year, 9, DateTime.DaysInMonth(year, 9), 23, 59, 59, 999);

            else // 4th Quarter = October 1 to December 31
                return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        /// <summary>
        /// Get quarter
        /// </summary>
        /// <param name="month">month</param>
        /// <returns>quarter of year</returns>
        public static Quarter GetQuarter(Month month)
        {
            if (month <= Month.March) // 1st Quarter = January 1 to March 31
                return Quarter.First;

            else if ((month >= Month.April) && (month <= Month.June)) // 2nd Quarter = April 1 to June 30
                return Quarter.Second;

            else if ((month >= Month.July) && (month <= Month.September)) // 3rd Quarter = July 1 to September 30
                return Quarter.Third;

            else // 4th Quarter = October 1 to December 31
                return Quarter.Fourth;
        }

        public static DateTime GetEndOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March) // go to last quarter of previous year
                return GetEndOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else //return last quarter of current year
                return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March) // go to last quarter of previous year
                return GetStartOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);

            else //return last quarter of current year
                return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }
        #endregion

        #region Weeks
        public static DateTime GetStartOfLastWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            DateTime dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            DateTime dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Months

        public static DateTime GetStartOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month,
               DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth(Month.December, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth((Month)DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth(Month.December, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth((Month)DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }
        #endregion

        #region Years
        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12,
              DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }
        #endregion

        #region Days
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        #endregion
        #region Xulychuoi trong postgrest

        public static string getDTValue(DateTime Values)
        {
            return string.Format("'{0}-{1}-{2} {3}:{4}:{5}'::timestamp", new object[] { Values.Year, Values.Month, Values.Day, Values.Hour, Values.Minute, Values.Second });
        }

        public static string getDValue(DateTime Values)
        {
            return string.Format("{0}-{1}-{2}", Values.Year, Values.Month, Values.Day);
        }

        public static string getDValue(DateTime Values, string DateType)
        {
            switch (DateType)
            {
                case "DMY":
                    return string.Format("{0}-{1}-{2}", Values.Day, Values.Month, Values.Year);

                case "MDY":
                    return string.Format("{0}-{1}-{2}", Values.Month, Values.Day, Values.Year);

                case "YMDT":
                    return string.Format("{0}-{1}-{2} {3}:{4}:{5}", new object[] { Values.Year, Values.Month, Values.Day, Values.Hour, Values.Minute, Values.Second });

                case "DMYT":
                    return string.Format("{0}-{1}-{2} {3}:{4}:{5}", new object[] { Values.Day, Values.Month, Values.Year, Values.Hour, Values.Minute, Values.Second });
            }
            return string.Format("{0}-{1}-{2}", Values.Year, Values.Month, Values.Day);
        }

        public static string getFDValue(DateTime Values)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", new object[] { Values.Day, Values.Month, Values.Year, Values.Hour, Values.Minute, Values.Second });
        }
        
        #endregion

    }
}
