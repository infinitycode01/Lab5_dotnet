namespace Lab5_dotnet;

public class StudentCollection
{
    private List<Student> _students = new List<Student>();

    public List<Student> Students
    {
        get { return _students; }
        init { _students = value; }
    }

    public double MaxAverageGrade
    {
        get 
        {
            if (Students.Count == 0)
            {
                return 0;
            }
            return Students.Max(student => student.AverageGrade);
        }
    }

    public IEnumerable<Student> MasterEducation
    {
        get
        {
            return Students.Where(student => student.EducationForm == Education.Master);
        }
    }

    public void AddDefaults()
    {
        for (int i = 0; i < 3; i++)
        {
            Students.Add(new Student());
        }
    }

    public void AddStudents(Student[] students)
    {
        _students.AddRange(students);
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        Console.ForegroundColor = ConsoleColor.Cyan;
        sb.AppendLine("\x1b[1mList of Students:\x1b[0m");
        
        int i = 1;
        foreach (var student in Students)
        {
            sb.Append(i + ") " + student.ToString());
            i++;
        }

        return sb.ToString();
    }

    public string ToShortString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        Console.ForegroundColor = ConsoleColor.Cyan;
        sb.AppendLine("\x1b[1m(short)List of Students:\x1b[0m");

        int i = 1;
        foreach (var student in Students)
        {
            sb.Append(i + ") " + student.ToShortString());
            i++;
        }

        return sb.ToString();
    }

    public void SortByLastName()
    {
        Students.Sort();
    }

    public void SortByBirthDate()
    {
        Students.Sort(new BirthDateComparer());
    }

    public void SortByAverageGrade()
    {
        Students.Sort(new AverageGradeComparer());
    }

    public List<Student> AverageMarkGroup(double value)
    {
        return Students.Where(student => student.AverageGrade == value).ToList();
    }
}