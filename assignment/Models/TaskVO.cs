using System;
using System.ComponentModel;

namespace assignment.Models
{
    public class TaskVO
    {
        public TaskVO()
        {
        }

        [DisplayName("Task ID")]
        public String tid { get; set; }

        [DisplayName("First Name")]
        public String firstName { get; set; }

        [DisplayName("Last Name")]
        public String lastName { get; set; }

        [DisplayName("Task")]
        public String task { get; set; }

        [DisplayName("Status")]
        public String status { get; set; }

        [DisplayName("Iteration")]
        public String iteration { get; set; }

        public override string ToString()
        {
            return "TaskVO: " + tid + " " + firstName + " " + lastName
                 + " " + task + " " + status + " " + iteration;
        }
    }
}
