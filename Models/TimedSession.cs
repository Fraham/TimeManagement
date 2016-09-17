using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement.Models
{
    public class TimedSession
    {
        private TimeSpan startTime = new TimeSpan(0);
        private TimeSpan endTime = new TimeSpan(0);

        private TimeSpan elapsedTime;

        public TimedSession()
        {

        }

        public TimedSession(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        private void ProcessTime()
        {
            if (StartTime == null || EndTime == null)
            {
                ElapsedTime = new TimeSpan(0);
            }
            else
            {
                ElapsedTime = EndTime - StartTime;
            }
        }

        #region Properties

        public TimeSpan StartTime
        {
            get
            {
                if (startTime == null)
                {
                    startTime = new TimeSpan(0);
                }

                return startTime;
            }

            set
            {
                if (value == null)
                {
                    value = new TimeSpan(0);
                }

                startTime = value;

                ProcessTime();
            }
        }

        public string StartTimeText
        {
            get
            {
                return StartTime.ToString("HH:mm:ss");
            }
            set
            {
                StartTime = TimeSpan.ParseExact(value, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                if (endTime == null)
                {
                    endTime = new TimeSpan(0);
                }

                return endTime;
            }

            set
            {
                if (value == null)
                {
                    value = TimeSpan.ParseExact("00:00:00", "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }

                endTime = value;

                ProcessTime();
            }
        }

        public string EndTimeText
        {
            get
            {
                return EndTime.ToString("HH:mm:ss");
            }
            set
            {
                try
                {
                    EndTime = TimeSpan.ParseExact(value, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (FormatException FE)
                {
                    FE.ToString();
                }
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (elapsedTime == null)
                {
                    elapsedTime = new TimeSpan();
                }

                return elapsedTime;
            }

            set
            {
                elapsedTime = value;
            }
        }

        public string ElapsedTimeText
        {
            get
            {
                try
                {
                    return elapsedTime.ToString();
                }
                catch (FormatException FE)
                {
                    return FE.ToString() + elapsedTime.ToString();
                }
            }
        }

        #endregion Properties
    }
}
