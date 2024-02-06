namespace PhoneBook.TestConsole
{
    public class Contact // модель класса
    {
        #region Свойства
        /// <summary>Имя</summary>
        public string Name { get; }

        /// <summary>Фамилия</summary>
        public string LastName { get; }

        /// <summary>Номер телефона</summary>
        public long PhoneNumber { get; }

        /// <summary>Почтовый адрес</summary>
        public string Email { get; }

        #endregion

        #region Конструктор
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        #endregion
    }
}
