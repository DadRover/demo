using HomeWork2.Handlers;
using System.Threading.Tasks;
using System;
using HomeWork2.Contracts;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace HomeWork2.Services
{
    internal class CoreService
    {
        private static CoreService instance;
        private static readonly object lockObj = new object();

        private static CoreHandler _coreHandler;
        private static DisplayHandler _displayHandler;

        private CoreService()
        {
            _coreHandler = new CoreHandler();
            _displayHandler = new DisplayHandler();
        }

        public static CoreService GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new CoreService();
                        }
                    }
                }
                return instance;
            }
        }

        public void Run()
        {            
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            _displayHandler.WriteWelcome();
            _displayHandler.WriteMenu();

            do
            {
                cki = Console.ReadKey();
                UserСhoice(cki.Key);
            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void UserСhoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    ShowTasks();
                    break;
                case ConsoleKey.F2:
                    CrateTask();
                    break;
                case ConsoleKey.F3:
                    DeleteTask();
                    break;
                case ConsoleKey.F4:
                    EditTask();
                    break;
                case ConsoleKey.F5:
                    ShowStorages();
                    break;
                case ConsoleKey.F6:
                    CrateStorage();
                    break;
                case ConsoleKey.F7:
                    DeleteStorage();
                    break;
            }
        }

        private static void EditTask()
        {
            Console.WriteLine("В каком хранилище?");
            string storageCode = _displayHandler.RequestStorageCode();

            if (!_coreHandler.IsExistStorageByCode(storageCode))
            {
                Console.WriteLine("Хранилище с таким кодом отсутствует.");
            }
            else
            {
                string taskCode = _displayHandler.RequestTaskCode();
                Console.WriteLine("Введите новые параметры задачи:");
                UserTask userTask = _displayHandler.RequestUserTask();
                _coreHandler.EditTask(storageCode, taskCode, userTask);
            }
        }

        /// <summary>
        /// Удалить Хранилище.
        /// </summary>
        private static void DeleteStorage()
        {
            string storageCode = _displayHandler.RequestStorageCode();
            if (!_coreHandler.IsExistStorageByCode(storageCode))
            {
                Console.WriteLine("Хранилище с таким кодом отсутствует. Сначала добавьте хранилище.");
            }
            else
            {
                _coreHandler.DeleteStorage(storageCode);
                Console.WriteLine("Хранилище удвлено.");
            }

            _displayHandler.WaitingForAction();
        }

        /// <summary>
        /// Создать хранилище.
        /// </summary>
        private static void CrateStorage()
        {
            UserStorage userStorage = _displayHandler.RequestUserStorage();
            _coreHandler.Add(userStorage);
            Console.WriteLine("Новое хранилище добавлено.");
            _displayHandler.WaitingForAction();
        }

        /// <summary>
        /// Показать Хранилища.
        /// </summary>
        private static void ShowStorages()
        {
            List<UserStorage> storeages = _coreHandler.GetStorages();
            if (storeages != null && storeages.Count > 0)
            {
                Console.WriteLine("Список хранилищ:");
                Console.WriteLine("Код | Наименование | Кол-во задач");
                foreach (var storeage in storeages)
                {
                    Console.WriteLine($"{storeage.Code} | {storeage.Name} | {storeage.UserTasks.Count}");
                }
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
        }

        /// <summary>
        /// Удалить Задачу.
        /// </summary>
        private static void DeleteTask()
        {
            Console.WriteLine("В каком хранилище?");
            string storageCode = _displayHandler.RequestStorageCode();

            if (!_coreHandler.IsExistStorageByCode(storageCode))
            {
                Console.WriteLine("Хранилище с таким кодом отсутствует.");
            }
            else
            {
                string taskCode = _displayHandler.RequestTaskCode();
                if (!_coreHandler.DeletaTaskIfExist(storageCode, taskCode)) 
                {
                    Console.WriteLine("Задача с таким кодом отсутствует.");
                }

            }
        }

        /// <summary>
        /// Создать Задачу.
        /// </summary>
        private static void CrateTask()
        {
            UserTask userTask = _displayHandler.RequestUserTask();            
            string storageCode = _displayHandler.RequestStorageCode();

            if (!_coreHandler.IsExistStorageByCode(storageCode))
            {
                Console.WriteLine("Хранилище с таким кодом отсутствует. Сначала добавьте хранилище.");
            }
            else
            {
                _coreHandler.Add(userTask, storageCode);
                Console.WriteLine("Новое хранилище добавлено.");
            }
            _displayHandler.WaitingForAction();
        }

        /// <summary>
        /// Показать Задачи.
        /// </summary>
        private static void ShowTasks()
        {
            List<UserStorage> storeages = _coreHandler.GetStorages();
            if (storeages != null && storeages.Count > 0)
            {
                Console.WriteLine("Список задач:");
                Console.WriteLine("Код | Наименование | хранилище");
                foreach (var storeage in storeages)
                {
                    foreach (var userTask in storeage.UserTasks)
                    {
                        Console.WriteLine($"{userTask.Code} | {userTask.Name} | {storeage.Code} ({storeage.Name})");
                    }
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст.");
            }
        }
    }
}
