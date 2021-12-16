public record RrgRule(string Left, string First, string? Second);

public class RightRegularGrammerToStateMachine {
    public IList<Vertex> ToStateMachine(RrgRule[] rules) {
        return rules.Select(r => new Vertex(r.Left, r.First, r.Second ?? "END")).ToList();
    }
}