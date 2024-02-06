namespace PhoneBook.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Анастасия", "Иванова", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Капризов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            //Сортировка методом расширения
            var sortedPhoneBook=phoneBook.OrderBy(p=>p.Name).ThenBy(p=>p.LastName);

            //Сортировка LINQ
            //var sortedPhoneBook = from p in phoneBook
                                //  orderby p.Name, p.LastName 
                                //  select p;


            int resultTake = 0;
            while (true)
            {
                Console.WriteLine("\nВведите количество выводимой информации: ");
                if (ReadKeyChar(out  resultTake))
                    break;
                else
                    Console.WriteLine("\nНеверное значение");
            }
           
            while (true)
            {
                Console.WriteLine("\nВыберите номер страницы: ");
                if (ReadKeyChar(out int pageNumber))
                {
                    if ( pageNumber < 1 || pageNumber > (int)Math.Ceiling(sortedPhoneBook.ToList().Count / (double)resultTake))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Страницы не существует");
                    }
                    else
                    {
                        // пропускаем нужное количество элементов и берем 2 для показа на странице
                        var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * resultTake).Take(resultTake);
                        Console.WriteLine();

                        // выводим результат
                        foreach (var entry in pageContent)
                            Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                        Console.WriteLine();
                    }
                }
            }

            static bool ReadKeyChar(out int result)
            {
                // Читаем введенный с консоли символ
                var key = Console.ReadKey().KeyChar;
                // проверяем, число ли это
                return int.TryParse(key.ToString(), out result);   
            }
        }
    }
}