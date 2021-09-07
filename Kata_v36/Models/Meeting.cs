using System;

namespace Scheduler.Models
{
    public class Meeting
    {
        public DateTime Start;
        public TimeSpan Duration;
        public Applicant Applicant;

        public Meeting(DateTime start)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(30);
            Applicant = null;
        }
        public Meeting(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
            Applicant = null;

        }

        public bool Overlap(Meeting meeting)
        {
            bool endIsBefore = (Start + Duration) < meeting.Start;
            bool startIsAfter = (meeting.Start + meeting.Duration) < Start;

            return !(endIsBefore || startIsAfter);
        }

        public override string ToString()
        {
            string date = Start.ToString("d'/'M'/'yy/");

            //string timeOfDay = Start.ToString("HH:mm") + " - " + Start.Add(Duration).ToString("HH:mm");

            //string endOfMeeting = Start.ToString(duration
            //timeOfDay = TimeSpan(add)
            string meetingStart = Start.ToString("HH:mm");

            DateTime end = Start + Duration;
            string meetingEnd = end.ToString(("HH:mm"));









            string info = date + " " + meetingStart + " - " + meetingEnd;

            if (Applicant != null)
                info += " with: " + Applicant.Name;

            return info;
        }
    }
}
