namespace Lab5_dotnet;

public class AverageGradeComparer: IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x is null && y is null)
            return 0;
        if (x is null)
            return -1;
        if (y is null)
            return 1;

        double xAverageGrade = x.AverageGrade;
        double yAverageGrade = y.AverageGrade;

        if (xAverageGrade < yAverageGrade)
            return -1;
        else if (xAverageGrade > yAverageGrade)
            return 1;
        else
            return 0;
    }
    
}