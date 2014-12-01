using System;

namespace DecoratedTeacher
{
    public interface ITeacher
    {
        String Name { get; set; }
        int Salary { get; set; }
        string ToString();
    }
}