
using System;
using System.Linq;

namespace Display.Clock.Text
{

    public static class ClockText
    {
        private const string Half = "Half";
        private const string Past = "past";
        private const string To = "to";
        private const string Oclock = "O'Clock";

        public static string TalkingClock(string time)
        {
            var output = "";
            string minuteString;
            var ts = TimeSpan.Parse(time);
            int hour = ts.Hours;
            int minute = ts.Minutes;

            string[] numNames = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve" };
            if (hour == 0)
            {
                hour = 12;
            }
            else if (hour > 12)
            {
                hour -= 12;
            }


            var hourString = numNames[hour - 1];

            if (minute == 30)
            {
                output = DisplayTimeInText(Half, Past, hourString);
            }
            if ((minute > 00) && (minute < 30))
            {
                minuteString = CalculateMinute(minute);
                output = DisplayTimeInText(minuteString, Past, hourString);
            }
            else if (minute > 30)
            {

                minuteString = CalculateMinute(60 - minute);
                hourString = numNames[hour];
                output = DisplayTimeInText(minuteString, To, hourString );
            }
            else if (minute == 00)
            {
                output = DisplayTimeInText(hourString, Oclock, null);
            }

            return output;
        }

        private static string DisplayTimeInText(string strFirst, string strSecond, string strThird)
        {
            return $"{strFirst} {strSecond} {strThird}";
        }

        private static string CalculateMinute(int minute)
        {
            var minuteString = "";

            string[] oneArray = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] teenArray= { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tenArray = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty" };

            if (Enumerable.Range(1, 10 - 1).Contains(minute))
            {

                minuteString = oneArray[minute - 1];
            }
            else if (Enumerable.Range(10, 20 - 10).Contains(minute))
            {
                minuteString = teenArray[minute - 10];
            }
            else if (Enumerable.Range(20, 60 - 20).Contains(minute))
            {
                var ones = minute % 10;
                var tens = minute - ones;
                if (ones > 0)
                {
                    minuteString = tenArray[tens / 10] + " " + oneArray[ones - 1];
                }
                else
                {
                    minuteString = tenArray[tens / 10];
                }
            }

            return minuteString;
        }

    };

}

