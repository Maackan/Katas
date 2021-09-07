using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Scheduler.Exceptions;

namespace Scheduler.Models
{
    public class CaseWorker
    {
        public string Name;
        public List<Meeting> Meetings;

        public CaseWorker()
        {
            Meetings = new List<Meeting>();

            DateTime startOfWork = DateTime.Today.AddHours(8);
            for (int i = 0; i < 6; i++)
            {
                
                DateTime startOfMeeting = startOfWork.AddHours(i);
                Meeting meeting = new Meeting(startOfMeeting);

                Meetings.Add(meeting);
            }
        }

        public void NewDateAdded(DateTime start)
        {
            Meeting newMeeting = new Meeting(start);

            
                foreach (Meeting meeting in Meetings)
                {
                    if (meeting.Overlap(newMeeting))
                    {
                        throw new MeetingOverlapException((meeting));
                        Debug.Write("meeting time already booked");
                    }

                    
                    // TODO kasta MeetingOverlapException om två möten överlappar
                }
           

            Meetings.Add(newMeeting);
        }

        public void ChangeMeeting(int index, DateTime newStart)
        {
            Meeting meetingToChange = Meetings[index];
            Meeting attemptMeeting = new Meeting(newStart, meetingToChange.Duration);

            foreach (Meeting meeting in Meetings)
            {
                if (meeting.Overlap(attemptMeeting))
                {
                    throw new MeetingOverlapException(meeting);
                    
                }
                else if (meeting == meetingToChange)
                    continue;

                // TODO kasta MeetingOverlapException om två möten överlappar
            }

            meetingToChange.Start = newStart;
        }
    }
}
