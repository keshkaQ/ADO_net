using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }    
        public decimal Price { get; set; }    
        public int Quantity { get; set; }    
        public DateTime DateAdded { get; set; }
        public ProductModel()
        {
            
        }
        public ProductModel(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
        public ProductModel(int id, string name, string description, decimal price, int quantity, DateTime dataAdded)
        {
            Id = id;  
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            DateAdded = dataAdded;
        }
        public override string ToString()
        {
            return $"Id: {Id}\n    ProductName: {Name}\n    Description: {Description}\n    Price: {Price}\n    Quantity: {Quantity}\n";
        }
    }
}
