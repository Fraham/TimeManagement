using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement.Models
{
    public class TimedProject
    {
        private ObservableCollection<TimedSession> sessions = new ObservableCollection<TimedSession>();

        private string totalTime = "testing";

        public TimedProject()
        {

        }

        public TimedProject(ObservableCollection<TimedSession> sessions)
        {
            Sessions = sessions;
        }

        public string TotalTime
        {
            get
            {
                TimeSpan ts = new TimeSpan();
                foreach (TimedSession session in Sessions){
                    ts = ts.Add(session.ElapsedTime);
                }

                totalTime = ts.ToString();
                return totalTime;
            }
            set
            {
                totalTime = value;
            }
        }

        public ObservableCollection<TimedSession> Sessions
        {
            get
            {
                return sessions;
            }

            set
            {
                sessions = value;
            }
        }
    }
}
