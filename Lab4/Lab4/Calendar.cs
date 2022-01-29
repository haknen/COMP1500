namespace Lab4
{
    public static class Calendar
    {
        const int LONG_MONTH = 31;
        const int SHORT_MONTH = 30;
        const int LEAP_FEBRUARY = 29;
        const int FEBRUARY = 28;

        public static bool IsLeapYear(uint year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if(year % 400 == 0)
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            if(year >= 9999 || month < 1 || month > 12)
            {
                return -1;
            }

            else
            {
                if(month == 2)
                {
                    if(IsLeapYear(year))
                    {
                        return LEAP_FEBRUARY;
                    }
                    else
                    {
                        return FEBRUARY;
                    }
                }
                else if(month == 4 || month == 6 || month == 9 || month == 11)
                {
                    return SHORT_MONTH;
                }
                else
                {
                    return LONG_MONTH;
                }
            }
        }
    }
}
