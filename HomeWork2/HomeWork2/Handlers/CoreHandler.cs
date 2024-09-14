using HomeWork2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork2.Handlers
{
    internal class CoreHandler
    {
        private List<UserStorage> _userStorages;
        public CoreHandler()
        {
            _userStorages = new List<UserStorage>();
        }

        /// <summary>
        /// Добавить Хранилище.
        /// </summary>
        /// <param name="userStorage"><see cref="UserStorage"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(UserStorage userStorage)
        {
            _userStorages.Add(userStorage);
        }

        /// <summary>
        /// Проверим существует ли Хранилище c таким кодом.
        /// </summary>
        /// <param name="code">Код Хранилища.</param>
        /// <returns>Результат проверки true/false</returns>
        public bool IsExistStorageByCode(string code)
        {
            return _userStorages.Any(s => s.Code == code);
        }

        /// <summary>
        /// Удалить Хранилище
        /// </summary>
        /// <param name="code">Код Хранилища.</param>
        public void Delete(string code)
        {
            _userStorages.RemoveAll(t => t.Code == code);
        }

        /// <summary>
        /// Добавить Задачу.
        /// </summary>
        /// <param name="userTask"><see cref="UserTask"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(UserTask userTask, string storageCode)
        {
            var storage = _userStorages.Where(s => s.Code == storageCode).First();
            storage.UserTasks.Add(userTask);
        }

        /// <summary>
        /// Проверим существует ли такой код в Задачу.
        /// </summary>
        /// <param name="code">Код Хранилища.</param>
        /// <returns>Результат проверки true/false</returns>
        public bool IsExistTaskCode(string code)
        {
            return _userStorages.Any(s => s.Code == code);
        }

        /// <summary>
        /// Удалить Хранилище
        /// </summary>
        /// <param name="code">Код Хранилища.</param>
        public void DeleteStorage(string code)
        {
            UserStorage storage = _userStorages.First(t => t.Code == code);
            if (storage != null)
            {
                _userStorages.Remove(storage);
            }
        }

        public List<UserStorage> GetStorages()
        {
            return _userStorages;
        }

        public UserStorage GetStorageByCode(string code)
        {
            return _userStorages.Where(s => s.Code == code).Single();
        }

        internal bool DeletaTaskIfExist(string storageCode, string taskCode)
        {
            UserStorage storage = _userStorages.First(s => s.Code == storageCode);
            UserTask task = storage.UserTasks.SingleOrDefault(t => t.Code == taskCode);
            if (task != null)
            {
                storage.UserTasks.Remove(task);
                return true;
            }
            else
            {
                return false; 
            }

        }

        internal void EditTask(string storageCode, string taskCode, UserTask userTask)
        {
            if (DeletaTaskIfExist(storageCode, taskCode)) 
            {
                Add(userTask, storageCode);
            }            
        }
    }
}
