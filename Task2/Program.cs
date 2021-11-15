using System;
using Task1;

namespace Task2
{
    public delegate void SortTypeDelegate(byte sortDirection,ref string[] array);
    class Program // класс подписчик
    {
        static void Main(string[] args)
        {
            string[] surnames = new[]
            {
                "Иванов",
                "Петров",
                "Сидоров",
                "Садреев",
                "Александров"
            };
            SortType sortEventObject = new SortType();
            sortEventObject.sortHumansEvent += SortBySurname; // подписан обработчик события

            try
            {
                Console.WriteLine("До сортировки:");
                foreach (string surname in surnames)
                {
                    Console.WriteLine(surname);
                }
                Console.WriteLine("Выберите тип сортировки: 1 - сортировка А-Я, 2 - сортировка Я-А");
                string direction = Console.ReadLine();
                direction = direction.Trim();
                if (direction == "") throw new MyExpetion("Не выбран тип сортировки");
                else if (direction != "1" && direction != "2") throw new MyExpetion("Неверное значение параметра");                    
                else sortEventObject.StartSort(direction,ref surnames);

                Console.WriteLine("После сортировки:");
                foreach (string surname in surnames)
                {
                    Console.WriteLine(surname);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           

        }

        public static void SortBySurname(byte sortDirection, ref string[] array)
        {
            Array.Sort(array);
            if (sortDirection == 2) Array.Reverse(array);

        }
    }

    class SortType // класс издатель
    {
        public event SortTypeDelegate sortHumansEvent;

        protected virtual void OnSortHumansEvent(byte sortdirection, ref string[] array)
        {
            sortHumansEvent?.Invoke(sortdirection, ref array);
        }

        public void StartSort(string dir, ref string[] array)
        {
            
            OnSortHumansEvent(Convert.ToByte(dir), ref array);
        }
    }
}
