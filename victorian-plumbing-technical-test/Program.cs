using System;
using confirma_pay_technical_test;

namespace victorian_plumbing_technical_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainLoop = GameLoop.Initialise().Result;
            mainLoop.Start();
        }
    }
}
