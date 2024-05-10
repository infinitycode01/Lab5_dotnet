namespace Lab5_dotnet;

public class StudentListHandlerEventArgs: EventArgs
{
    public string CollectionName { get; init;}
    public string ChangeType { get; init; }
    public Student ObjectReference { get; init; }

    public StudentListHandlerEventArgs(string name, string type, Student reference)
    {
        CollectionName = name;
        ChangeType = type;
        ObjectReference = reference;
    }

    public override string ToString()
    {
        return "Name of collection: " + CollectionName + "\n" 
            + "Type: " + ChangeType + "\n" 
            + "Object: " + ObjectReference;
    }
}