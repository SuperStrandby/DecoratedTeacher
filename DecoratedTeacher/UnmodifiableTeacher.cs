using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratedTeacher
{
    public class UnmodifiableTeacher : ITeacher
    {
        private readonly ITeacher _teacher;
        private string _name;
        private int _salary;

        public UnmodifiableTeacher(ITeacher teacher)
        {
            if (teacher == null) throw new ArgumentNullException("teacher");
            _teacher = teacher;
        }

        public string Name
        {
            get { return _teacher.Name; }
            set { throw new NotSupportedException("Teacher object is unmodifiable"); }
        }

        public int Salary
        {
            get { return _teacher.Salary; }
            set { throw new NotSupportedException("Teacher object is unmodifiable"); }
        }

        public override string ToString()
        {
            return _teacher.ToString();
        }

        public override bool Equals(object obj)
        {
            return _teacher.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _teacher.GetHashCode();
        }
    }
}
