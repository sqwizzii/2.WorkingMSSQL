using _2.WorkingMSSQL.Data;
using _2.WorkingMSSQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace _2.WorkingMSSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            using (var context = new MyAppContext())
            {
                context.Database.Migrate();
                DatabaseSeeder.SeedData();

                while (true)
                {
                    Console.WriteLine("\n1. Показати всіх користувачів");
                    Console.WriteLine("2. Знайти користувача за ID");
                    Console.WriteLine("3. Додати нового користувача");
                    Console.WriteLine("4. Змінити користувача");
                    Console.WriteLine("5. Видалити користувача");
                    Console.WriteLine("6. Вийти");
                    Console.Write("Оберіть опцію: ");
                    string option = Console.ReadLine()!;

                    switch (option)
                    {
                        case "1":
                            var users = context.Users.ToList();
                            users.ForEach(user => Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}, {user.Phone}"));
                            break;

                        case "2":
                            Console.Write("Введіть ID користувача: ");
                            if (int.TryParse(Console.ReadLine(), out int searchId))
                            {
                                var foundUser = context.Users.Find(searchId);
                                Console.WriteLine(foundUser != null ? $"{foundUser.Id}: {foundUser.FirstName} {foundUser.LastName}, {foundUser.Phone}" : "Користувача не знайдено.");
                            }
                            else Console.WriteLine("Некоректний ID.");
                            break;

                        case "3":
                            var newUser = new UserEntity();
                            Console.Write("Ім'я: ");
                            newUser.FirstName = Console.ReadLine()!;
                            Console.Write("Прізвище: ");
                            newUser.LastName = Console.ReadLine()!;
                            Console.Write("Email: ");
                            newUser.Email = Console.ReadLine();
                            Console.Write("Телефон: ");
                            newUser.Phone = Console.ReadLine()!;
                            Console.Write("Дата народження (рік-місяць-день): ");
                            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly birthDate))
                            {
                                newUser.BirthDate = birthDate;
                                context.Users.Add(newUser);
                                context.SaveChanges();
                                Console.WriteLine("Користувач доданий.");
                            }
                            else Console.WriteLine("Некоректна дата.");
                            break;

                        case "4":
                            Console.Write("Введіть ID користувача: ");
                            if (int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                var existingUser = context.Users.Find(updateId);
                                if (existingUser != null)
                                {
                                    Console.Write($"Нове ім'я ({existingUser.FirstName}): ");
                                    string newFirstName = Console.ReadLine()!;
                                    if (!string.IsNullOrWhiteSpace(newFirstName))
                                        existingUser.FirstName = newFirstName;

                                    Console.Write($"Нове прізвище ({existingUser.LastName}): ");
                                    string newLastName = Console.ReadLine()!;
                                    if (!string.IsNullOrWhiteSpace(newLastName))
                                        existingUser.LastName = newLastName;

                                    Console.Write($"Новий Email ({existingUser.Email}): ");
                                    string newEmail = Console.ReadLine()!;
                                    if (!string.IsNullOrWhiteSpace(newEmail))
                                        existingUser.Email = newEmail;

                                    Console.Write($"Новий телефон ({existingUser.Phone}): ");
                                    string newPhone = Console.ReadLine()!;
                                    if (!string.IsNullOrWhiteSpace(newPhone))
                                        existingUser.Phone = newPhone;

                                    Console.Write($"Нова дата народження ({existingUser.BirthDate}): ");
                                    if (DateOnly.TryParse(Console.ReadLine(), out DateOnly newBirthDate))
                                        existingUser.BirthDate = newBirthDate;

                                    context.SaveChanges();
                                    Console.WriteLine("Користувач оновлений.");
                                }
                                else Console.WriteLine("Користувача не знайдено.");
                            }
                            else Console.WriteLine("Некоректний ID.");
                            break;

                        case "5":
                            Console.Write("Введіть ID користувача: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteId))
                            {
                                var userToDelete = context.Users.Find(deleteId);
                                if (userToDelete != null)
                                {
                                    context.Users.Remove(userToDelete);
                                    context.SaveChanges();
                                    Console.WriteLine("Користувач видалений.");
                                }
                                else Console.WriteLine("Користувача не знайдено.");
                            }
                            else Console.WriteLine("Некоректний ID.");
                            break;

                        case "6":
                            return;

                        default:
                            Console.WriteLine("Невірна опція.");
                            break;
                    }
                }
            }
        }
    }
}
