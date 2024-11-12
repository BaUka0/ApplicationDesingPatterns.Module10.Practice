using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            RoomBookingSystem roomBookingSystem = new RoomBookingSystem();
            RestaurantSystem restaurantSystem = new RestaurantSystem();
            EventManagementSystem eventManagementSystem = new EventManagementSystem();
            CleaningService cleaningService = new CleaningService();

            HotelFacade hotelFacade = new HotelFacade(roomBookingSystem, restaurantSystem, eventManagementSystem, cleaningService);

            hotelFacade.BookRoomWithDinnerAndCleaning(DateTime.Now.AddDays(1), DateTime.Now.AddDays(3), 2, 101);

            hotelFacade.OrganizeEvent("Конференция", DateTime.Now.AddDays(5), DateTime.Now.AddDays(7), new string[] { "Проектор", "Экран" }, 2, 10);

            hotelFacade.BookTableWithTaxi(DateTime.Now.AddHours(2), 4);


            Department departmentA = new Department { Name = "ДБУ" };
            Employee John = new Employee { Name = "John", Salary = 20000 };
            Employee Jane = new Employee { Name = "Jane", Salary = 25000 };
            Employee Yety = new Employee { Name = "Yety", Salary = 19000 };

            departmentA.AddComponent(John);
            departmentA.AddComponent(Jane);
            departmentA.AddComponent(Yety);

            Department departmentB = new Department { Name = "ДБА" };

            Employee Kina = new Employee { Name = "Kina", Salary = 50000 };
            Employee Kana = new Employee { Name = "Kana", Salary = 45000 };

            departmentB.AddComponent(Kina);
            departmentB.AddComponent(Kana);

            Department departmentC = new Department { Name = "ДББ" };

            Employee Anna = new Employee { Name = "Anna", Salary = 60000 };
            Employee Kane = new Employee { Name = "Kane", Salary = 55000 };

            departmentC.AddComponent(Anna);
            departmentC.AddComponent(Kana);

            departmentA.AddComponent(departmentB);
            departmentA.AddComponent(departmentC);

            Console.WriteLine("Структура организации:");
            departmentA.Display();
            Console.WriteLine($"ДБУ зарплата: {departmentA.GetTotalBudget()}");
            Console.WriteLine($"Общее количество сотрудников: {departmentA.GetTotalEmployees()}");

        }
    }
}
