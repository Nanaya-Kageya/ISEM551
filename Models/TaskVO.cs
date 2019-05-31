using System;
using System.ComponentModel;

namespace Models
{
    public class TaskVO
    {
        public TaskVO()
        {
        }

        [DisplayName("FirstName")]
        public String firstName { get; set; }

        [DisplayName("LastName")]
        public String lastName { get; set; }

        [DisplayName("Task")]
        public String task { get; set; }

        [DisplayName("Status")]
        public String status { get; set; }

    }
}
