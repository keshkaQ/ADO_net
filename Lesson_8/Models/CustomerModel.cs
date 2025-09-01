using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public byte[] Picture { get; set; }
        public override string ToString()
        {
            return $"{id,5} {FirstName,20} {LastName,20} {Convert.ToDateTime(DateOfBirth).ToShortDateString(),20}";
        }
    }
}
