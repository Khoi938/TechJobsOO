using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        // [HttpPost]
        public IActionResult Index(int id)
        {
            var x = jobData.Jobs.ToArray();
            if (id > x.Length || id < 1)
            {
                TempData["Invalid"] = "Invalid Id";
                return Redirect("/Search/ById");
            }
            // TODO #1 - get the Job with the given ID and pass it into the view

            Job entry = jobData.Find(id);
            return View("Views/Job/Index.cshtml",entry);
         
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            
            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.City),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.Skill),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.Position)
                };
                /*
                Employer newEmp  = new Employer();
                List<Employer> emp = jobData.Employers.ToList();
                foreach (Employer x in emp)
                {
                    if (x.ID == newJobViewModel.EmployerID)
                    {
                        newEmp = x;
                    }
                }
                CoreCompetency newCore = new CoreCompetency();
                List<CoreCompetency> core = jobData.CoreCompetencies.ToList();
                foreach (CoreCompetency x in core)
                {
                    if (x.ID == newJobViewModel.Skill)
                    {
                        newCore = x;
                    }
                }
                Location newLoca = new Location();
                List<Location> loca = jobData.Locations.ToList();
                foreach (Location x in loca)
                {
                    if (x.ID == newJobViewModel.City)
                    {
                        newLoca = x;
                    }
                }
                PositionType newPo = new PositionType();
                List<PositionType> po = jobData.PositionTypes.ToList();
                foreach (PositionType x in po)
                {
                    if (x.ID == newJobViewModel.Position)
                    {
                        newPo = x;
                    }
                }

                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    CoreCompetency = newCore,
                    Employer = newEmp,
                    Location = newLoca,
                    PositionType = newPo,
                }; */
                jobData.Jobs.Add(newJob);
                
                return Redirect("/Job?Id="+newJob.ID);
            }
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return View(newJobViewModel);
        }
    }
}
