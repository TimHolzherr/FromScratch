public record Vertex(string Source, string Value, string Destination);

public class StateMachineSolver
{
    Dictionary<string, List<Vertex>>? _srcDict;

    public string? Solve(IList<Vertex> vertices, string[] input, string start)
    {
        if (input.Length == 0)
        {
            return start;
        }

        _srcDict ??= vertices.Select(v => v.Source)
            .Distinct()
            .ToDictionary(src => src,
                src => vertices.Where(v => v.Source == src)
                    .ToList());

        if (!_srcDict.ContainsKey(start))
        {
            return null;
        }

        var possiblePaths = _srcDict[start].Where(v => v.Value == input[0]);

        foreach (var path in possiblePaths)
        {
            var result = Solve(vertices, input[Range.StartAt(1)], path.Destination);
            if (result != null)
            {
                Console.WriteLine($"{path.Source}-->{path.Value}-->{path.Destination}");
                return result;
            }
        }

        return null;
    }
}