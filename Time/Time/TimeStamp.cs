using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStamp
{
    class TimeStamp 
    {

        private int hours;
        private int minutes;
        private int seconds;

        private const int MIN_TIME = 0;

      //constructors
        public TimeStamp()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public TimeStamp(int _hours,int _minutes,int _seconds){
            SetHours(_hours);
            SetMinutes(_minutes);
            SetSeconds(_seconds);
            }
        
        //Member Methods
        public TimeStamp ConvertFromSeconds(int SecondsToConvert)
        {
            hours = SecondsToConvert / 3600;
            minutes = (SecondsToConvert % 3600) / 60;
            seconds = SecondsToConvert % 60;
            return this;

        }
        public int ConvertToSeconds()
        {
            int totalSeconds;
            totalSeconds = ((hours * 60) * 60) + (minutes * 60) + (seconds);
            return totalSeconds;
        }
        public void AddSeconds(int TheSeconds)
        {        
           TheSeconds = ConvertToSeconds();
           ConvertFromSeconds(TheSeconds);
           seconds += 30;
            
        }
        public void ReadFromConsole()
        {
            int hours = GetValue("Please enter number of hours:(0-23) ",0,23);
            int minutes = GetValue("Please enter number of minutes: (0-59)", 0, 59);
            int seconds = GetValue("Please enter number of seconds: (0-59)", 0, 59);

        }
        private int GetValue(string errorMessage,int min,int max)
        {
            int input;
            bool validInput;
            validInput = int.TryParse(Console.ReadLine(),out input);
            while(validInput == false || input < min||input > max)
            {
                Console.WriteLine("Error! Please enter a number in between {0} and {1}", min,max);
                validInput = int.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static public TimeStamp AddTwoTimeStamps(TimeStamp TimeStampOne, TimeStamp TimeStampTwo)
        {
            TimeStamp t3 = new TimeStamp();

           int seconds = TimeStampOne.ConvertToSeconds() + TimeStampTwo.ConvertToSeconds();

            return t3.ConvertFromSeconds(seconds);
        }
        //Getters
        public int GetHours()
        {
            return hours;
        }
        public int GetMinutes()
        {
            return minutes;
        }
    public int GetSeconds()
        {
            return seconds;
        }
        //Properties
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                seconds = value;
            }
        }
        //Setters
        public void SetHours(int _hours)
        {
            if (_hours < MIN_TIME)
                throw new ArgumentException("Hours cannot be less then 0", "hours");
        }
        public void SetMinutes(int _minutes)
        {
            if (_minutes < MIN_TIME || _minutes > 60)
                throw new ArgumentException("Minutes cannot be less then 0", "minutes");
        }
        public void SetSeconds(int _seconds)
        {
            if (_seconds < MIN_TIME || _seconds > 60)
                throw new ArgumentException("Seconds cannot be less then 0", "seconds");
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", hours, minutes, seconds);
        }

    }
}
