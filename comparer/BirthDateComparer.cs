namespace Lab5_dotnet;

public class BirthDateComparer: IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        return DateTime.Compare(x.BirthDate, y.BirthDate);
    }
}