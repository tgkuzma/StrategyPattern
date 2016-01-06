using System;
using System.Runtime.InteropServices;

namespace Tests
{
    internal class SystemDateManager
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSystemTime(ref SystemDateTime lpSystemTime);

        [DllImport("kernel32.dll")]
        private static extern void GetSystemTime(ref SystemDateTime lpSystemTime);

        private struct SystemDateTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
        }

        internal static void SetSystemDate(ushort month, ushort day, ushort year)
        {
            var systemDate = new SystemDateTime();
            GetSystemTime(ref systemDate);

            systemDate.Month = month;
            systemDate.Day = day;
            systemDate.Year = year;

            if (!SetSystemTime(ref systemDate))
            {
                var exceptionCode = Marshal.GetLastWin32Error();
                if (exceptionCode == 1314)
                {
                    throw new ApplicationException("You must run Visual Studio as an Administrator to modify the system's date/time.");
                }
                throw new ApplicationException(string.Format("The system threw a Windows Exception with code {0}", exceptionCode));
            }
        }
    }
}