// input: 1+2*3
// rules:
// num = '1'
// num = '2'
// num = '3'
// expr = '1' op_exp
// expr = '2' op_exp
// expr = '3' op_exp
// op_exp = + expr
// op_exp = - expr
// op_exp = * expr

var input = "1+2*3";

var rules = new RrgRule[] {
    new RrgRule("expr", "1", null),
    new RrgRule("expr", "2", null),
    new RrgRule("expr", "3", null),
    new RrgRule("expr", "1", "op_expr"),
    new RrgRule("expr", "2", "op_expr"),
    new RrgRule("expr", "3", "op_expr"),
    new RrgRule("op_expr", "*", "expr"),
    new RrgRule("op_expr", "+", "expr"),
    new RrgRule("op_expr", "-", "expr"),    
};

var transformer = new RightRegularGrammerToStateMachine();
var vertices = transformer.ToStateMachine(rules);
foreach (var ver in vertices) {
    Console.WriteLine(ver);
}

var solver = new StateMachineSolver();
var end = solver.Solve(vertices, input.ToArray().Select(c => c.ToString()).ToArray() , vertices[0].Source);
if (end == "END") {
    Console.WriteLine("Success");
}
else {
    Console.WriteLine($"Failure: got {end}");
}