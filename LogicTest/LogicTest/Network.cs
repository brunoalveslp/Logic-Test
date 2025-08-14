using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTest;

public class Network
{
    private List<int>[] _graph;

    public Network(int numberOfElements)
    {
        if (numberOfElements <= 0)
        {
            throw new ArgumentException("The number of elements must be greater than zero.");
        }
        
        _graph = new List<int>[numberOfElements];


        for (int i = 0; i < numberOfElements; i++)
        {
            _graph[i] = new List<int>();
        }
    }

    public void Connect(int nodeA, int nodeB)
    { 
        if(nodeA < 0 || nodeB < 0 || nodeA == nodeB)
        {
            throw new ArgumentException("The nodes must have values greather than zero and not equal.");
        }

        if (!IsDirectlyConnected(nodeA,nodeB))
        {
            _graph[nodeA-1].Add(nodeB-1);
            _graph[nodeB-1].Add(nodeA-1);
        }
        else
        {
            throw new InvalidDataException("The connection alrealy exist.");
        }
    }


    public void Disconnect(int nodeA, int nodeB)
    {
        if (nodeA < 0 || nodeB < 0 || nodeA == nodeB)
        {
            throw new ArgumentException("The nodes must have values greather than zero and not equal.");
        }

        if(IsDirectlyConnected(nodeA,nodeB))
        {
            _graph[nodeA-1].Remove(nodeB-1);
            _graph[nodeB-1].Remove(nodeA-1);
        } else
        {
            throw new InvalidDataException("There are no connections between the value provided.");
        }
    }

    public bool Query(int nodeA, int nodeB)
    {
        bool result = false;

        if (nodeA < 0 || nodeB < 0 || nodeA == nodeB)
        {
            throw new ArgumentException("The nodes must have values greather than zero and not equal.");
        }

        if (IsDirectlyConnected(nodeA, nodeB))
        {
            result = true;
        }

        if(IsUndirectlyConnected(nodeA, nodeB))
        {
            result = true;
        }

        return result;
    }

    public int LevelConnection(int nodeA, int nodeB)
    {
        return 0;
    }


    public bool IsDirectlyConnected(int nodeA, int nodeB) => _graph[nodeA-1].Contains(nodeB - 1) && _graph[nodeB-1].Contains(nodeA - 1);

    public bool IsUndirectlyConnected(int nodeA, int nodeB)
    {
        return false;
    }
    public void PrintGraph()
    {
        for (int i = 0; i < _graph.Length; i++)
        {
            string nodeConections = String.Join(", ",_graph[i].Select(x => x +1));
            Console.Write($"{i + 1}: ");
            Console.WriteLine(nodeConections);
        }
    }
}
