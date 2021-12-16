var vertices = new List<Vertex> {
    new Vertex("A", "1", "C"),
    new Vertex("A", "1", "B"),
    new Vertex("B", "2", "A"),
    new Vertex("A", "3", "C"),
};

var stateMachineSolver = new StateMachineSolver();

Console.WriteLine(stateMachineSolver.Solve(vertices, new string[] { "1", "2", "3" }, "A"));