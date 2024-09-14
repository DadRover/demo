using HomeWork2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2.Handlers
{
    public class DisplayHandler
    {
        public DisplayHandler()
        {
        }

        public void WriteWelcome() =>
            Console.WriteLine("Сервис управления задачами запущен!");


        public void WriteMenu()
        {
            Console.WriteLine("Меню:");

            Console.WriteLine("F1 - Поосмотреть задачи;");
            Console.WriteLine("F2 - Добавить задачу;");
            Console.WriteLine("F3 - Удалить задачу;");
            Console.WriteLine("F3 - Редактировать задачу;");

            Console.WriteLine("F5 - Посмотреть хранилища;");
            Console.WriteLine("F6 - Добавить хранилище;");
            Console.WriteLine("F7 - Удилить хранилище;");

            Console.WriteLine("Esc - Выход;");
        }

        internal UserStorage RequestUserStorage()
        {
            Console.WriteLine("Введмте код нового хранилища :");
            string codeStorage = Console.ReadLine();
            Console.WriteLine("Введмте название нового хранилища :");
            string nameStorage = Console.ReadLine();

            UserStorage userStorage = new UserStorage
            {
                Name = nameStorage,
                Code = codeStorage,
                UserTasks = new List<UserTask>(),
            };

            return userStorage;
        }

        internal UserTask RequestUserTask()
        {
            Console.WriteLine("Введмте код новой задачи:");
            string codeUserTask = Console.ReadLine();
            Console.WriteLine("Введмте название нового хранилища :");
            string nameUserTask = Console.ReadLine();

            UserTask userTask = new UserTask
            {
                Name = nameUserTask,
                Code = codeUserTask,
            };

            return userTask;
        }

        internal string RequestStorageCode()
        {
            Console.WriteLine("Введмте код хранилища:");
            return Console.ReadLine();
        }

        internal void WaitingForAction()
        {
            Console.WriteLine("Ожидание действия F1 - F7/(Esc)...");
        }

        internal string RequestTaskCode()
        {
            Console.WriteLine("Введмте код задачи:");
            return Console.ReadLine();
        }
    }
}
