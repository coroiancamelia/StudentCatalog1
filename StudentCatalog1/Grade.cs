using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalog1
{
    class Grade
    {
        
            public double Value { get; set; }
            public DateTime DateTime { get; set; }
            public string Subject { get; set; }

            public Grade(double value, string subject)
            {
                Value = value;
                DateTime = DateTime.Now;
                Subject = subject;
            }
        
    }

}

