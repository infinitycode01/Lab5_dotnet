namespace Lab5_dotnet;

public class StudentCollection
{
    public string CollectionName { get; init; }
    private List<Student> _students = new List<Student>();
    
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    public event StudentListHandler ?StudentCountChanged;
    public event StudentListHandler ?StudentReferenceChanged;

    public StudentCollection(string collectionName)
    {
        CollectionName = collectionName;
    }

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
            Student student = new();
            Students.Add(student);
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Add", student));
        }
    }

    public void AddStudents(Student[] students)
    {
        foreach (Student student in students)
        {
            Students.Add(student);
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Add", student));
        }

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

    public bool Remove(int j)
    {
        if (j >= 0 && j < Students.Count)
        {
            var studentRef = Students[j];
            Students.RemoveAt(j);
            StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Remove", studentRef));
            return true;
        }
        else
        {
            return false;
        }
    }

    public Student this[int index]
    {
        get 
        {
            if (index >= 0 && index < Students.Count)
            {
                return Students[index];
            }
            else
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range.");
            }
        }
        set 
        {
            if (index >= 0 && index < Students.Count)
            {
                Students[index] = value;
                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Update", value));
            }
            else
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range.");
            }
        }
    }
}