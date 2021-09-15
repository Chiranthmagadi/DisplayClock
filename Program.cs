using System;
using System.Net.Http.Headers;

namespace Display.Clock.Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the time in HH:MM Or Press enter to read the current time.");
            string strCurrentTime = Console.ReadLine();
            
            if(string.IsNullOrEmpty(strCurrentTime))
             strCurrentTime = DateTime.Now.ToString("HH:mm");

            string result= ClockText.TalkingClock(strCurrentTime);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
