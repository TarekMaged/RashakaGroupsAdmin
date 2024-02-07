using System;
using System.Linq;

namespace RashakaGroupsAdmin.Models
{
    public class DateConverter
    {
        public static long ConvertDateTimeTicksTOUnixTimestamp(DateTime tableDateTime)
        {
            // DateTime now = Convert.ToDateTime(tableDateTime);
            long unixTimestamp = tableDateTime.Ticks;
            unixTimestamp = (unixTimestamp - 621355968000000000) / 10000000;
            return unixTimestamp;

        }
        public static DateTime ConvertUnixTimestampToDateTimeTicks(double timestamp)
        {
            // This is an example of a UNIX timestamp for the date/time 11-04-2005 09:25.

            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(timestamp);

            // The dateTime now contains the right date/time so to format the string,
            // use the standard formatting methods of the DateTime object.
            //  string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();

            return dateTime;
            // Print the date and time
            //    System.Console.WriteLine(printDate);

        }
        public static long ConvertDateTimeTicksTOUnixTimestampWithoutSecond(DateTime tableDateTime)
        {
            // DateTime now = Convert.ToDateTime(tableDateTime);
            DateTime objDateTime = new DateTime(tableDateTime.Year, tableDateTime.Month, tableDateTime.Day, tableDateTime.Hour, tableDateTime.Minute, 0);
            long unixTimestamp = objDateTime.Ticks;
            unixTimestamp = (unixTimestamp - 621355968000000000) / 10000000;
            return unixTimestamp;

        }

        private static readonly char[] _HexDigits = {
                        '0', '1', '2', '3', '4', '5', '6', '7',
                        '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
                        };
        public static string ToHexString(string sPrefix, byte[] bytes)
        {
            int k = sPrefix.Length;

            int j = bytes.Length;

            char[] chars = new char[k + (j * 2)];

            sPrefix.CopyTo(0, chars, 0, k);

            for (int i = 0; i < j; i++)
            {
                int b = bytes[i];
                int c = (i * 2) + k;
                chars[c] = _HexDigits[b >> 4];
                chars[c + 1] = _HexDigits[b & 0xF];
            }
            return new string(chars);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
