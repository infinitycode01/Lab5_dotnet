using System.Collections;

namespace Lab5_dotnet;

public class Student: Person, IComparable<Student>
{
    private Education _educationForm;
    private int _groupNumber;
    private List<Test>? _tests;
    private List<Exam>? _examsTaken;

    public Student(Person studentData, Education educationForm, int groupNumber)
        : base(studentData.FirstName, studentData.LastName, studentData.BirthDate)
    {
        EducationForm = educationForm;
        GroupNumber = groupNumber;
        Tests = new List<Test>();
        ExamsTaken = new List<Exam>();
    }

    public Student() : this(studentData: new Person(), educationForm: Education.Bachelor, groupNumber: 111) { }

    public static Student Create(int n)
    {
        return new Student(new Person("Dima" + n, "Badichel", new DateTime(2000, 10, 10)), Education.Bachelor, 311);

    }
    public Person StudentData
    {
        get { return this; }
        init 
        {
            FirstName = value.FirstName;
            LastName = value.LastName;
            BirthDate = value.BirthDate;
        }
    }

    public Education EducationForm
    {
        get { return _educationForm; }
        init { _educationForm = value; }
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        init 
        {
            if (value <= 100 || value > 699)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(GroupNumber),
                    message: "Group number must be between 100 and 699."
                );
            }
            _groupNumber = value;
        }
    }

    public List<Exam>? ExamsTaken
    {
        get { return _examsTaken; }
        init { _examsTaken = value; }
    }

    public List<Test>? Tests
    {
        get { return _tests; }
        init { _tests = value; }
    }

    public double AverageGrade
    {
        get 
        {
            if (ExamsTaken == null || ExamsTaken.Count == 0)
            {
                return 0;
            }

            double gradeSum = 0;
            foreach (var exam in ExamsTaken)
            {
                gradeSum += ((Exam)exam).Assessment;
            }

            return gradeSum / ExamsTaken.Count;
        }
    }

    public void AddExams(params Exam[] newExams)
    {
        if (newExams == null || newExams.Length == 0)
        {
            return;
        }

        if (_examsTaken == null)
        {
            _examsTaken = new List<Exam>();
        }

        _examsTaken.AddRange(newExams);
    }

    public void AddTests(params Test[] newTests)
    {
        if (newTests == null || newTests.Length == 0)
        {
            return;
        }

        if (_tests == null)
        {
            _tests = new List<Test>();
        } 

        _tests.AddRange(newTests);
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
        sb.AppendLine(base.ToString());
        sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {EducationForm}");
        sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {GroupNumber}");
        sb.AppendLine("\x1b[1mTests:\x1b[0m");
        if (Tests == null || Tests.Count == 0)
        {
            sb.AppendLine("Tests is empty");
        }
        else
        {
            foreach (var test in Tests)
            {
                if (test != null)
                {
                    sb.AppendLine(test.ToString());
                }
            }
        }
        sb.AppendLine("\x1b[1mExams Taken:\x1b[0m");
        if (ExamsTaken == null || ExamsTaken.Count == 0)
        {
            sb.AppendLine("Exams is empty");
        }
        else
        {
            foreach (var exam in ExamsTaken)
            {
                if (exam != null)
                {
                    sb.AppendLine(exam.ToString());
                }
            }
        }
        return sb.ToString();
    }

    public new string ToShortString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine("\x1b[1mStudent Data:\x1b[0m");
        sb.AppendLine(base.ToString());
        sb.AppendLine($"\x1b[1mEducation Form:\x1b[0m {EducationForm}");
        sb.AppendLine($"\x1b[1mGroup Number:\x1b[0m {GroupNumber}");
        sb.AppendLine($"\x1b[1mAverage grade:\x1b[0m {AverageGrade}");

        return sb.ToString();
    }

    public ArrayList GetAllTestAndExam()
    {
        if ((Tests == null || Tests.Count == 0) && (ExamsTaken == null || ExamsTaken.Count == 0)) 
        {
            return new ArrayList();
        }

        ArrayList allTestAndExam = new ArrayList();

        Console.WriteLine("All tests and exams:");
        if (Tests != null && Tests.Count > 0)
        {
            foreach (var item in Tests)
            {
                allTestAndExam.Add(item);
            }
        }
        
        if (ExamsTaken != null && ExamsTaken.Count > 0)
        {
            foreach (var item in ExamsTaken)
            {
                allTestAndExam.Add(item);
            }
        }
        return allTestAndExam;
    }

    public int CompareTo(Student student)
    { 
        return FirstName.CompareTo(student.FirstName);
    }
}