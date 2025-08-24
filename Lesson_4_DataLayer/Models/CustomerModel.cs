using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_DataLayer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CustomerModel(int id, string firstName,string lastName, DateTime dateOfBirth)
        {
            Id = id; 
            FirstName = firstName;
            LastName = lastName;    
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"ID: {Id}, FirstName: {FirstName}, LastName: {LastName}, DateOfBirth: {DateOfBirth.ToShortDateString()}";
        }
    }
}
