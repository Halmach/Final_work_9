using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] ex = new Exception[5]
            {
                new IndexOutOfRangeException("Индекс находится за пределами границ массива"),
                new ArgumentNullException("Аргумент, передаваемый в метод — null"),
                new DivideByZeroException("Знаменатель в операции деления или целого числа Decimal равен нулю."),
                new FormatException("Значение не находится в соответствующем формате " +
                                    "для преобразования из строки методом преобразования"),
                new MyExpetion("Пользовательское исключение")
            };

            for (int i = 0; i < ex.Length; i++)
            {
                try
                {
                    throw ex[i];
                }
                catch (Exception e) when (e is IndexOutOfRangeException)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) when (e is ArgumentNullException)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) when (e is DivideByZeroException)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) when (e is FormatException)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) when (e is MyExpetion)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
