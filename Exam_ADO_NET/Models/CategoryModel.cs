using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryModel()
        {
            
        }
        public CategoryModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public CategoryModel(int id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return $"Id: {Id}\n    CategoryName: {Name}\n    Description: {Description}\n";
        }
    }
}
