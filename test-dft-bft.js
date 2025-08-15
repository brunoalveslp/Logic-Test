const graph = [
    [],
    [2],     
    [1,6,4],
    [],
    [2],     
    [8],     
    [2],      
    [],     
    [5]      
]

function depthFirst(graph, nodeA, nodeB){
    const stack = [nodeA]
    const allNodesConnected = new Set()

    while(stack.length > 0)
    {
        const current = stack.pop()

        if(!allNodesConnected.has(current))
        {
            allNodesConnected.add(current)
            if(!graph[current]) continue

            for(let neighbor of graph[current]){
                stack.push(neighbor)
            }
        }
    }

    if(allNodesConnected.has(nodeB))
        console.log("Connected")
    else
        console.log("Not Connected")

}


function breadthFirst(graph, nodeA, nodeB) {
    const queue = [nodeA]
    const allNodesConnected = new Set()

    while(queue.length > 0){
        const current = queue.shift()

        if(!allNodesConnected.has(current)){
            allNodesConnected.add(current)

            for(let neighborNode of graph[current]){
                queue.push(neighborNode)
            }
        }
    }

    if(allNodesConnected.has(nodeB)) 
        console.log("Connected")
    else 
        console.log("Not Connected")
}

// depthFirst(graph, 1, 2)
// depthFirst(graph, 1, 6)
// depthFirst(graph, 1, 8)

breadthFirst(graph, 1, 2)
breadthFirst(graph, 1, 6)
breadthFirst(graph, 1, 8)