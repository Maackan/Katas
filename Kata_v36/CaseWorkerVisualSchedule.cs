using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Exceptions;
using Scheduler.Models;

namespace Scheduler
{
    public partial class CaseWorkerVisualSchedule : UserControl
    {
        private readonly CaseWorker _caseWorker;
        private readonly Action _meetingAddedHandler;
        public CaseWorkerVisualSchedule(CaseWorker caseWorker, Action meetingAddedHandler)
        {
            _meetingAddedHandler = meetingAddedHandler;
            _caseWorker = caseWorker;
            InitializeComponent();

            label_CaseWorkerName.Text = _caseWorker.Name;
            dateTimePicker.Format = DateTimePickerFormat.Custom;

            button_Add.Click += Button_Add_Click;
            button_ChangeDate.Click += Button_ChangeDate_Click;

            
            RefreshDisplayedMeetings();
        }

        private void Button_ChangeDate_Click(object sender, EventArgs e)
        {
            int index = listBox_Meetings.SelectedIndex;
            try
            {
                _caseWorker.ChangeMeeting(index, dateTimePicker.Value);
                RefreshDisplayedMeetings();
            }
            catch //Detta är en Catch all så den fångar upp alla typer av fel. Man kan skriva (Exception exception) så är det en grundklass
            {
                MessageBox.Show("Overlapping another meeting. Try Again.");
            }
            

        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                _caseWorker.NewDateAdded(dateTimePicker.Value);
                RefreshDisplayedMeetings();
                _meetingAddedHandler();
            }
            catch (MeetingOverlapException exception) //Specifikt för det felet vi "sökt". Använder sig av exception som Björn skapat sen innan i koden så jag kan kalla på exception .Message
            {
                MessageBox.Show(exception.Message, "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        public void RefreshDisplayedMeetings()
        {
            List<string> content = new List<string>();

            foreach (Meeting meeting in _caseWorker.Meetings)
            {
                content.Add(meeting.ToString());
            }

            listBox_Meetings.DataSource = content;
        }
    }
}
