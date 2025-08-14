namespace LogicTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Network net = new(8);
            string res = "No";

            // Test 1-2, 6-2, 2-4, 5-8
            net.Connect(1, 2);
            net.Connect(6,2);
            net.Connect(2, 4);
            net.Connect(5, 8);

            // net.Disconnect(1, 2);
            if(net.Query(1, 4))
            {
                res = "Yes";
            }
            Console.WriteLine("Connected: "+ res);

            net.PrintGraph();
        }
    }
}
