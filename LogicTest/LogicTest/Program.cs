using System.Xml;

namespace LogicTest;

internal class Program
{
    static void Main(string[] args)
    {
        Network net = new(8);
        string res = "No";

        // Test connecting nodes 1-2, 6-2, 2-4, 5-8
        Console.WriteLine("Connecting nodes: 1-2, 6-2, 2-4, 5-8 ");
        Console.WriteLine("-----------------------------------------------------------------------------");
        net.Connect(1, 2);
        net.Connect(6, 2);
        net.Connect(2, 4);
        net.Connect(5, 8);

        Console.WriteLine("Disconnecting nodes: 2-6");
        Console.WriteLine("-----------------------------------------------------------------------------");

        net.Disconnect(6, 2);

        Console.WriteLine("Testing if nodes are connected:");
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine("1-2: " + IsConnected(net, 1, 2));
        Console.WriteLine("1-6: " + IsConnected(net, 1, 6));
        Console.WriteLine("1-4: " + IsConnected(net, 1, 4));
        Console.WriteLine("1-8: " + IsConnected(net, 1, 8));


        Console.WriteLine("Testing nodes connection Level: ");
        Console.WriteLine("-----------------------------------------------------------------------------");

        Console.WriteLine($"Connection Level of nodes 1-5 (Expected to be 0): {net.LevelConnection(1, 5)}");
        Console.WriteLine($"Connection Level of nodes 1-2 (Expected to be 1): {net.LevelConnection(1, 2)}");
        Console.WriteLine($"Connection Level of nodes 1-4 (Expected to be 2): {net.LevelConnection(1, 4)}");

    }


    public static string IsConnected(Network network, int nodeA, int nodeB) => network.Query(nodeA, nodeB) ? "Connected": "Not Connected";
}