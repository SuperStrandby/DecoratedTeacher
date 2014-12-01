using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratedTeacher
{
    public class ThreadsafeTeacher : ITeacher
    {
        private readonly ITeacher _teacher;

        public ThreadsafeTeacher(ITeacher teacher)
        {
            if (teacher == null) throw  new ArgumentNullException("teacher");
            _teacher = teacher;
        }

        public string Name
        {
            get
            {
                lock (this)
                {
                    return _teacher.Name;
                }
            }
            set
            {
                lock (this)
                {
                    _teacher.Name = value;
                }
            }
        }

        public int Salary
        {
            get
            {
                lock (this)
                {
                    return _teacher.Salary;
                }
            }
            set
            {
                lock (this)
                {
                    _teacher.Salary = value;
                }
            }
        }

        public override string ToString()
        {
            lock (this)
            {
                return _teacher.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            lock (this)
            {
                return _teacher.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            lock (this)
            {
                return _teacher.GetHashCode();
            }
        }
    }
}
