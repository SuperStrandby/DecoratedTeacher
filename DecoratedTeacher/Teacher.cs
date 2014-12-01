using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratedTeacher
{
    public class Teacher : ITeacher, IEquatable<ITeacher>
    {
        public String Name { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return string.Format("{0} , {1}", Name, Salary);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ITeacher)) return false;
            return Equals((ITeacher)obj);
        }

        public bool Equals(ITeacher other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Salary == other.Salary;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Salary;
                return hashCode;
            }
        }
    }
}
