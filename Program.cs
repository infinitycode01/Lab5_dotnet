namespace Lab5_dotnet;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student(new Person(), Education.Master, 111);
        Student student2 = new Student(new Person(), Education.Bachelor, 222);
        Student student3 = new Student(new Person(), Education.SecondEducation, 333);

        Student[] students1 = [student1, student2, student3];
        Student[] students2 = [student2, student3];

        StudentCollection studentCollection1 = new StudentCollection("first");
        StudentCollection studentCollection2 = new StudentCollection("second");

        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        studentCollection1.StudentCountChanged += journal1.StudentCountChaged;
        studentCollection1.StudentReferenceChanged += journal1.StudentReferenceChaged;

        studentCollection1.StudentCountChanged += journal2.StudentCountChaged;
        studentCollection1.StudentReferenceChanged += journal2.StudentReferenceChaged;
        
        studentCollection2.StudentCountChanged += journal2.StudentCountChaged;
        studentCollection2.StudentReferenceChanged += journal2.StudentReferenceChaged;   

        studentCollection1.AddStudents(students2);
        studentCollection1.Remove(1);
        studentCollection1.AddDefaults();
        studentCollection1.Remove(3);   
        studentCollection1[2] = new Student();

        studentCollection2.AddStudents(students1);
        studentCollection2.Remove(1);
        studentCollection2[1] = new Student();

        Console.WriteLine(journal1);
        Console.WriteLine(journal2); 
    }
}
