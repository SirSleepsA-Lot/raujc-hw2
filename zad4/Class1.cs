using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad1;

namespace zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {

            int[] int_array = intArray.OrderBy(i => i).ToArray();

            var int2_array = int_array.Select((item, index) =>
                         new
                         {
                             Key = item,
                             Count = (index == 0 || int_array.ElementAt(index - 1) != item) ?
                             int_array.Skip(index).TakeWhile(d => d == item).Count() : -1
                         }
                         ).Where(d => d.Count != -1).ToArray();

            return int2_array.Select(i => "Broj " + i.Key + " ponavlja se " + i.Count + " puta").ToArray();

        }




        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.Where(j => j.Gender == Gender.Female).Count() == 0).ToArray(); ;
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            var a = universityArray.Select(i => i.Students.Count());
            var b = a.Average();
            return universityArray.Where(i => (i.Students.Count() < b)).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(i => i.Students.Where(j => j.Gender == i.Students.First().Gender).Count() == i.Students.Count()).SelectMany(i => i.Students).Distinct().ToArray();





        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(i => i.Students).GroupBy(j => j).Where(k => k.Count() > 1).Select(s => s.Key).ToArray();

        }
    }
}
