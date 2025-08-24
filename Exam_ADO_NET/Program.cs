using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Exam_ADO_NET.Models;
using Exam_ADO_NET.DataLayer;
using Exam_ADO_NET.DataLayers;

namespace Exam_ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productDataLayer = new Product_DataLayer();
            var userDataLayer = new User_DataLayer();
            var categoryDataLayer = new Category_DataLayer();

            //// 1.1 Добавление пользователя
            //var newUser = new UserModel("kuzmin45", "kuzya_password", "Кузьмин", "Геннадий", "Сергеевич", "kuzmingena@gmail.com", "+79893905512");
            //bool resAdded = userDataLayer.AddUser(newUser);
            //Console.WriteLine(resAdded ? "Пользователь успешно удален" : "Пользователь не был удален");

            //// 1.2 Удаление пользователя
            //bool isDeletedUser = userDataLayer.DeleteUser(28);
            //Console.WriteLine(isDeletedUser ? "Пользователь успешно удален" : "Пользователь не был удален");

            //// 1.3 Получение всех пользователей
            //var allUsers = userDataLayer.GetAllUsers();
            //foreach (var user in allUsers)
            //{
            //    Console.WriteLine(user);
            //}

            //// 1.4 Обновление пользователя
            //var userToUpdate = new UserModel
            //{
            //    Id = 29,
            //    Login = "kuzmin42",
            //    Password = "kuzya_new_password",
            //    FirstName = "Кузьмин",
            //    LastName = "Геннадий",
            //    Patronymic = "Сергеевич",
            //    Email = "kuzmingena@gmail.com",
            //    Phone = "+79304892199"
            //};
            //bool isUserUpdated = userDataLayer.UpdateUser(userToUpdate);
            //Console.WriteLine(isUserUpdated ? $"Данные пользователя '{userToUpdate.LastName} {userToUpdate.FirstName}' успешно обновлены" : "Данные пользователя не были обновлены");

            //// 1.5 Получение пользователя по ID
            //var userById = userDataLayer.GetUserById(2);
            //Console.WriteLine(userById);

            //// 2.1.Добавление продукта
            //var newProduct = new ProductModel("Холодильник Samsung", "Холодильник с морозильной камерой", 49999, 12);
            //bool isProductAdded = productDataLayer.AddProduct(newProduct);
            //Console.WriteLine(isProductAdded ? $"Товар '{newProduct.Name}' был успешно добавлен" : $"Товар {newProduct.Name} не был добавлен");

            //// 2.2 Обновление продукта
            //var productToUpdate = new ProductModel()
            //{
            //    Id = 31,
            //    Name = "Холодильник Philips",
            //    Description = "Умный холодильник с морозильной камерой",
            //    Price = 65000,
            //    Quantity = 21
            //};
            //bool isProductUpdated = productDataLayer.UpdateProduct(productToUpdate);
            //Console.WriteLine(isProductUpdated ? $"Данные товара '{productToUpdate.Name}' успешно обновлены" : "Данные товара не были обновлены");

            //// 2.3 Получение всех продуктов
            //var allProducts = productDataLayer.GetAllProducts();
            //foreach (var product in allProducts)
            //{
            //    Console.WriteLine(product);
            //}

            //// 2.4 Удаление продукта
            //bool isDeletedProduct = productDataLayer.DeleteProduct(30);
            //Console.WriteLine(isDeletedProduct ? "Товар был успешно удален" : "Товар не был удален");

            //// 2.5 Получение продукта по Id
            //var product = productDataLayer.GetProductById(1);
            //Console.WriteLine(product);

            //// 3.1.Добавление категории
            //var newCategory = new CategoryModel("Товары для кошек и собак", "Без описания");
            //bool isCategoryAdded = categoryDataLayer.AddCategory(newCategory);
            //Console.WriteLine(isCategoryAdded ? $"Категория '{newCategory.Name}' была успешно добавлена" : $"Категория {newCategory.Name} не была добавлена");

            // 3.2 Обновление категории
            //var categoryToUpdate = new CategoryModel()
            //{
            //    Id = 16,
            //    Name = "Товары для животных",
            //    Description = "Лежанки, корма, домики, шлейки, поводки, игрушки"
            //};
            //bool isCategoryUpdate = categoryDataLayer.UpdateCategory(categoryToUpdate);
            //Console.WriteLine(isCategoryUpdate ? $"Данные категории '{categoryToUpdate.Name}' успешно обновлены" : $"Данные категории '{categoryToUpdate.Name}' не были обновлены");

            // 3.3 Получение всех категорий
            //var allCategories = categoryDataLayer.GetAllCategories();
            //foreach (var category in allCategories)
            //{
            //    Console.WriteLine(category);
            //}

            //// 3.4 Удаление категории
            //bool isDeletedCategory = categoryDataLayer.DeleteCategory(15);
            //Console.WriteLine(isDeletedCategory ? "Категория была успешно удалена" : "Категория не была удалена");

            //// 2.5 Получение категории по Id
            //var category = categoryDataLayer.GetCategoryById(1);
            //Console.WriteLine(category);

        }
    }
}
