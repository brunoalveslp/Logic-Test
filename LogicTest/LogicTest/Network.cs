using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            _graph[i] = new();
        }
    }

    public void Connect(int nodeA, int nodeB)
    { 
        AreNodesValid(nodeA, nodeB);

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
        AreNodesValid(nodeA, nodeB);

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

        AreNodesValid(nodeA, nodeB);

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
        AreNodesValid(nodeA, nodeB);


        if (IsDirectlyConnected(nodeA, nodeB))
        {
            return 1;
        }

        if( IsUndirectlyConnected(nodeA,nodeB))
        {
            return 2;
        }

        return 0;
    }


    public bool IsDirectlyConnected(int nodeA, int nodeB) => _graph[nodeA-1].Contains(nodeB - 1) && _graph[nodeB-1].Contains(nodeA - 1);

    public bool IsUndirectlyConnected(int nodeA, int nodeB)
    {
        if (IsDirectlyConnected(nodeA,nodeB))
        {
            return false;
        }

        HashSet<int> allNodesConnected = new();

        Stack<int> stack = new();

        stack.Push(nodeA-1);

        do
        {
            var currentNode = stack.Pop();

            if(currentNode == nodeB-1)
            {
                return true;
            }


            if (!allNodesConnected.Contains(currentNode))
            {
                allNodesConnected.Add(currentNode);
                foreach (var neighborNode in _graph[currentNode])
                {
                    stack.Push(neighborNode);
                }
            }

        }
        while (stack.Count > 0);

        return false;
    }

    public void AreNodesValid(int nodeA,int nodeB)
    {
        if (nodeA <= 0 || nodeA > _graph.Length || nodeB <= 0 || nodeB > _graph.Length)
        {
            throw new ArgumentOutOfRangeException($"The values must be between 1 and {_graph.Length}");
        }

        if(nodeA == nodeB)
        {
            throw new ArgumentException("The values must be different.");
        }
    }
}
