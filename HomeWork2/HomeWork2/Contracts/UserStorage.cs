using System.Collections.Generic;

namespace HomeWork2.Contracts
{
    /// <summary>
    /// Хранилище.
    /// </summary>
    public class UserStorage
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Задачи.
        /// </summary>
        public List<UserTask> UserTasks { get; set; }
    }
}
