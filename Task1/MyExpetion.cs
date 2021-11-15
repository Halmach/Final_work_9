using System;

namespace Task1
{
    public class MyExpetion : Exception
    {
        public MyExpetion(string message) : base(message)
        {

        }
    }
}