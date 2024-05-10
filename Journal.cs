using System.Text;

namespace Lab5_dotnet;

public class Journal
{
    private List<JournalEntry> _content = new List<JournalEntry>();

    public List<JournalEntry> Content
    {
        get { return _content; }
    }
    
    public void StudentCountChaged(object source, StudentListHandlerEventArgs args)
    {
        Content.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ObjectReference));
    }

    public void StudentReferenceChaged(object source, StudentListHandlerEventArgs args)
    {
        Content.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ObjectReference));
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in Content)
        {
            sb.Append(item);
            sb.AppendLine();
        }

        return sb.ToString();
    }
}