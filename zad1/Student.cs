using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{

    public class Student : IEquatable<Student>
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }



        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;
            return this.Name == other.Name && this.Jmbag == other.Jmbag && this.Gender == other.Gender;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Student);
        }

        public static bool operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Student a, Student b)
        {
            if (ReferenceEquals(a, b) && (ReferenceEquals(a, null) || ReferenceEquals(b, null))) return true;

            return !a.Equals(b);
        }
    }
    public enum Gender
    {
        Male, Female
    }
}
