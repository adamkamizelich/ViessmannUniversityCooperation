namespace DataAccessLayer
{
    using System;

    using DataAccessLayer.exampleADO;

    class Program
    {
        static void Main(string[] args)
        {
            ConnectedModelExample ex1 = new ConnectedModelExample();
            ex1.ReadAsync().GetAwaiter().GetResult();
            Console.ReadKey();

            DisconnectedModelExample ex2 = new DisconnectedModelExample();
            ex2.Read();
            Console.ReadKey();
        }
    }
}
