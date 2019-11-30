using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Developer : Employee
    {
        List<Project> projects;
        public Developer(int id, string firstname, string lastname, int salary, List<Project> projects) : base(id, firstname, lastname, salary, Department.Production)
        {
            this.projects = projects;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void SHowProjects()
        {
            Console.WriteLine("List of Projects");
            foreach (var p in projects)
                Console.WriteLine(p);
            Console.WriteLine();
        } 
    }
    struct Project
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; private set; }
        public string Details { get; set; }
        public enum ProjectState
        {
            open,
            closed
        }
        ProjectState state;

        public Project(string name, DateTime date, string details, ProjectState state)
        {
            this.ProjectName = name;
            this.StartDate = date;
            this.Details = details;
            this.state = state;
        }
        public override string ToString()
        {
            return $"ProjectName: {this.ProjectName}, StartDate: {this.StartDate}, Details: {this.Details}, ProjectState: {this.state}";
        }
    }
}
