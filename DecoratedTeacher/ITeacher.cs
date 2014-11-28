namespace DecoratedTeacher
{
    public interface ITeacher
    {
        string Name { get; set; }
        int Salary { get; set; }
        string ToString();
    }
}