using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataHelper;

namespace Scheduler.Models
{
    public class Scheduler
    {
        public List<Applicant> UnassignedApplicants;
        public List<CaseWorker> CaseWorkers;

        public Scheduler()
        {
            UnassignedApplicants = new List<Applicant>();
            CaseWorkers = new List<CaseWorker>();

            string[] randomNames = Helper.GetRandomNames(14, 123);

            for (int i = 0; i < 10; i++)
            {
                Applicant applicant = new Applicant();
                applicant.Name = randomNames[i];
                UnassignedApplicants.Add(applicant);
                //Debug.WriteLine("Applicant name:" + applicant.Name);// Detta hamnar i "output" ifall man vill testa i winforms t.ex som inte har console.
            }

            for (int i = 0; i < 4; i++)
            {
                CaseWorker caseWorker = new CaseWorker();
                caseWorker.Name = randomNames[10 + i];
                CaseWorkers.Add(caseWorker);
            }
        }

        public void RandomlyFillUpMeetings()
        {
            
            foreach (CaseWorker caseWorker in CaseWorkers)
            {
                foreach (Meeting meeting in caseWorker.Meetings)
                {
                    if (UnassignedApplicants.Count == 0)
                        return;

                    if (meeting.Applicant == null)
                    {

                        Random rand = new Random();
                        int randomIndex = rand.Next(0, UnassignedApplicants.Count); //TODO detta är inte slumpat.
                        
                        meeting.Applicant = UnassignedApplicants[randomIndex];
                        UnassignedApplicants.RemoveAt(randomIndex);
                        

                    }
                }
            }
        }
    }
}
