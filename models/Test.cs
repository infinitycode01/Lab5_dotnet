namespace Lab5_dotnet;

public class Test(string subjectName, bool isPassed)
{
    public string SubjectName { get; init; } = subjectName;
    public bool IsPassed { get; init; } = isPassed;

    public Test() : this("C#", true) {}

    public override string ToString() => "Subject name: " + SubjectName + "\n" + "Passed: " + IsPassed;
}