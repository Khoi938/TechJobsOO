using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
        // The current column
        public JobFieldType Column { get; set; }
        // All columns, for display
        public List<JobFieldType> Columns { get; set; }
        // View title
        public string Title { get; set; } = "";
    }
}
