namespace Serializer.App.Entities;

//[JsonDerivedType(typeof(Student))]
//[JsonDerivedType(typeof(UniversityStudent))]
public class Person
{
    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
}

public class Student : Person
{
    public Student(string name, string surname, string code)
        : base(name, surname)
    {
        Code = code;
    }

    public string Code { get; set; }
    public virtual List<Vote> Votes { get; set; }
}

public class UniversityStudent : Student
{
    public UniversityStudent(string name, string surname, string code)
        : base(name, surname, code)
    {
    }
}