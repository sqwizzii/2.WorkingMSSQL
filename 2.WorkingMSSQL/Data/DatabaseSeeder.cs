using _2.WorkingMSSQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2.WorkingMSSQL.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedData()
        {
            using (var context = new MyAppContext())
            {
                context.Database.Migrate();

                if (!context.Users.Any())
                {
                    var users = new List<UserEntity>
                    {
                        new UserEntity { FirstName = "Іван", LastName = "Підкаблучник", Phone = "+38(098) 235 22 90", BirthDate = new DateOnly(2000, 2, 27) },
                        new UserEntity { FirstName = "Мальвіна", LastName = "Комарова", Phone = "+38(066) 123 12 34", BirthDate = new DateOnly(2004, 4, 15) },
                        new UserEntity { FirstName = "Семен", LastName = "Заєць", Phone = "+38(097) 342 11 11", BirthDate = new DateOnly(2003, 6, 1) },
                        new UserEntity { FirstName = "Орел", LastName = "Білка", Phone = "+38(096) 234 11 45", BirthDate = new DateOnly(2006, 7, 12) },
                        new UserEntity { FirstName = "Денис", LastName = "Їжак", Phone = "+38(098) 205 20 10", BirthDate = new DateOnly(2010, 5, 19) }
                    };
                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}
