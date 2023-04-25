using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day22_Task
{
    public class Patient
    {
        public enum Status
        {
            Immediate = 0, 
            Urgent, 
            Delayed, 
            Expectant
        }
        public string name { get; set; }
        public Status status { get; set; }

        public Patient(string name, Status status) 
        {
            this.name = name;
            this.status = status;
        }
    }
}
