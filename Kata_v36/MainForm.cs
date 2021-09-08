using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Scheduler.Models;

namespace Scheduler
{
    public partial class MainForm : Form
    {
        private Models.Scheduler _scheduler;
        private List<CaseWorkerVisualSchedule> _visualSchedules;

        public MainForm()
        {
            InitializeComponent();

            _scheduler = new Models.Scheduler();
            _visualSchedules = new List<CaseWorkerVisualSchedule>();
            

            foreach (var caseWorker in _scheduler.CaseWorkers)
            {
                CaseWorkerVisualSchedule caseWorkerVisualSchedule = new CaseWorkerVisualSchedule(caseWorker, RefreshFreeSpotsLabel);
                caseWorkerVisualSchedule.Size = new Size(500, 400);
                


                flowLayoutPanel_CaseWorkerSchedules.Controls.Add(caseWorkerVisualSchedule);
                _visualSchedules.Add(caseWorkerVisualSchedule);
            }

            button_RandomlyAssignApplicants.Click += Button_RandomlyAssignApplicants_Click;

            RefreshApplicants();
            RefreshFreeSpotsLabel();
        }

        private void Button_RandomlyAssignApplicants_Click(object sender, System.EventArgs e)
        {
            _scheduler.RandomlyFillUpMeetings();

            RefreshApplicants();
            RefreshFreeSpotsLabel();
            foreach (CaseWorkerVisualSchedule visualSchedule in _visualSchedules)
            {
                visualSchedule.RefreshDisplayedMeetings();
            }
        }

        
        private void RefreshFreeSpotsLabel()
        {
            int availableSpots = 0;
            foreach (CaseWorker caseWorker in _scheduler.CaseWorkers)
            {
                foreach (Meeting meeting in caseWorker.Meetings)
                {
                    if (meeting.Applicant == null)
                        availableSpots += 1;
                }
            }
            label_FreeMeetingSpots.Text = "Free meeting spots: " + availableSpots;
        }

        private void RefreshApplicants()
        {
            List<string> content = new List<string>();

            foreach (Applicant applicant in _scheduler.UnassignedApplicants)
            {
                content.Add(applicant.Name);
            }

            listBox_Applicants.DataSource = content;
        }
    }
}
