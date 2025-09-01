using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;

namespace Lesson_7_Linq_to_SQL.Entity
{

    [Table(Name ="Customers")] // атрибут - говорит, что класс соответствует таблице в БД
    // Без атрибута - ORM будет искать таблицу "Customer"
    // С атрибутом - ORM ищет таблицу "Customers" 
    public class Customer
    {
        [Column(IsPrimaryKey=true,IsDbGenerated =true)]
        public int Id { get; set; }
        [Column]
        public string FirstName { get; set; }
         [Column]
        public string LastName { get; set; }
        [Column(CanBeNull =true)]
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return $"{Id,5} {FirstName,20} {LastName,20} {Convert.ToDateTime(DateOfBirth).ToShortDateString(),20}";
        }
    }
}
