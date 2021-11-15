using System;

namespace Task1
{
    class MyExpetion : Exception
    {
        public MyExpetion(string message) : base(message)
        {

        }
    }
}