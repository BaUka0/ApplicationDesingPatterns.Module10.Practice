using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public class RoomBookingSystem
    {
        public void Book(DateTime StartTime, DateTime EndTime, int peopleAmount)
        {
            Console.WriteLine($"Номер забронирован с {StartTime} до {EndTime} для {peopleAmount} человек.");
        }
        public void ProcessPay(double amount)
        {
            Console.WriteLine($"Оплата в размере {amount} произведена.");
        }
        public void CheckAvailability(DateTime StartTime, DateTime EndTime)
        {
            Console.WriteLine($"Проверка доступности номера с {StartTime} до {EndTime}.");
        }
        public void Cancel(int bookId)
        {
            Console.WriteLine($"Бронирование с ID {bookId} отменено.");
        }
    }
    public class RestaurantSystem
    {
        public void Notify(int roomNum, int peopleAmount)
        {
            Console.WriteLine($"Ресторан уведомлен о заказе столика для {peopleAmount} человек в номере {roomNum}.");
        }
        public void BookTable(DateTime time, int peopleAmount)
        {
            Console.WriteLine($"Столик забронирован на {time} для {peopleAmount} человек.");
        }
        public void OrderFood(string[] dishes)
        {
            Console.WriteLine("Заказ блюд:");
            foreach (string dish in dishes)
            {
                Console.WriteLine($"- {dish}");
            }
        }
    }
    public class EventManagementSystem
    {
        public void BookConfHall(DateTime StartTime, DateTime EndTime, string eventName)
        {
            Console.WriteLine($"Конференц-зал забронирован для мероприятия '{eventName}' с {StartTime} до {EndTime}.");
        }
        public void OrderEquipment(string[] equipment)
        {
            Console.WriteLine("Заказ оборудования:");
            foreach (string item in equipment)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
    public class CleaningService
    {
        public void Notify(DateTime StartTime, DateTime EndTime, int roomNum)
        {
            Console.WriteLine($"Служба уборки уведомлена о необходимости уборки номера {roomNum} с {StartTime} до {EndTime}.");
        }
        public void CleanSchedule(int roomNum, DateTime StartTime, DateTime EndTime)
        {
            Console.WriteLine($"Уборка номера {roomNum} запланирована на {StartTime} - {EndTime}.");
        }
        public void Clean(int roomNum)
        {
            Console.WriteLine($"Уборка номера {roomNum} выполнена.");
        }
    }
    public class HotelFacade
    {
        private RoomBookingSystem _roomBookingSystem;
        private RestaurantSystem _restaurantSystem;
        private EventManagementSystem _eventManagementSystem;
        private CleaningService _cleaningService;

        public HotelFacade(RoomBookingSystem roomBookingSystem, RestaurantSystem restaurantSystem, EventManagementSystem eventManagementSystem, CleaningService cleaningService)
        {
            _roomBookingSystem = roomBookingSystem;
            _restaurantSystem = restaurantSystem;
            _eventManagementSystem = eventManagementSystem;
            _cleaningService = cleaningService;
        }
        public void BookRoomWithDinnerAndCleaning(DateTime startTime, DateTime endTime, int peopleAmount, int roomNum)
        {
            _roomBookingSystem.Book(startTime, endTime, peopleAmount);
            _restaurantSystem.BookTable(startTime, peopleAmount);
            _cleaningService.CleanSchedule(roomNum, startTime, endTime);
        }
        public void OrganizeEvent(string eventName, DateTime startTime, DateTime endTime, string[] equipment, int numRooms, int peoplePerRoom)
        {
            _eventManagementSystem.BookConfHall(startTime, endTime, eventName);
            _eventManagementSystem.OrderEquipment(equipment);
            for (int i = 0; i < numRooms; i++)
            {
                _roomBookingSystem.Book(startTime, endTime, peoplePerRoom);
            }
        }
        public void BookTableWithTaxi(DateTime time, int peopleAmount)
        {
            _restaurantSystem.BookTable(time, peopleAmount);
        }
    }
    internal class Facade
    {
    }
}
