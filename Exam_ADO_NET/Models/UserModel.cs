using System;
namespace Exam_ADO_NET.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }

        public UserModel() { }
        public UserModel(string login, string password, string firstName, string lastName,
                       string patronymic, string email, string phone)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
            RegistrationDate = DateTime.Now;
        }

        // Конструктор для чтения из БД
        public UserModel(int id, string login, string password, string firstName, string lastName,
                       string patronymic, string email, string phone, DateTime registrationDate)
        {
            Id = id;
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
            RegistrationDate = registrationDate;
        }
        public override string ToString()
        {
            return $"Id: {Id}\n    FirstName: {FirstName}\n    LastName: {LastName}\n    Email: {Email}\n    Phone: {Phone}\n";
        }
    }
}
