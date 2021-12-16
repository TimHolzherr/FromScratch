var vertices = new List<Vertex> {
    new("A", "1", "C"),
    new("A", "1", "B"),
    new("B", "2", "A"),
    new("A", "3", "C"),
};

var stateMachineSolver = new StateMachineSolver();

Console.WriteLine(stateMachineSolver.Solve(vertices, new[] { "1", "2", "3" }, "A"));