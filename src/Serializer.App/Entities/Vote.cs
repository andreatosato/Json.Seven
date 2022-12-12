namespace Serializer.App.Entities;

//[JsonDerivedType(typeof(UniversityVote))]
public class Vote
{
    public Vote(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}

public class UniversityVote : Vote
{
    public UniversityVote(string course, int value)
        : base(value)
    {
        Course = course;
    }

    public string Course { get; set; }
}