using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApp.Shared.Data
{
    public class Bug
    {
        public int Id { get; set; }

        public string Summary { get; set; }

        public string BugPriority { get; set; }

        public string Assignee { get; set; }

        public string BugStatus { get; set; }
    }
}
