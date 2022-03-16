using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UP_3
{
   public static class Repository
    {
        const string PATH = @"Employers.txt";
        public static void WriteEmployee(Employee emp)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PATH, true, Encoding.Default))
                {
                    sw.WriteLine($"" +
                        $"{emp.Id}\t" +
                        $"{emp.LastName}\t" +
                        $"{emp.FirstName}\t" +
                        $"{emp.SecondName}\t" +
                        $"{emp.Passport}\t" +
                        $"{emp.PhoneNumber}\t" +
                        $"{emp.Email}");
                }
            }
            catch (Exception e)
            {

            }
        }

        public static Employee GetEmployee(uint id)
        {            
            var emps = GetEmployers();
            foreach(var e in emps)
            {
                if (e.Id == id) return e;
            }
            return null;
        }

        public static List<Employee> GetEmployers()
        {
            List<string> str = new List<string>();
            try
            {
                using(StreamReader sr = new StreamReader(PATH,Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        str.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {

            }
            List<Employee> emps = new List<Employee>();
            if (str.Any())
            {
                foreach (var e in str)
                {
                    emps.Add(new Employee(e));
                }
            }
            return emps;
        }

        public static bool FreeId(string arg)
        {
            try
            {
                uint id = uint.Parse(arg);

                if (GetEmployee(id) != null)
                {
                    return false;
                }

                return true;
            }
            catch(Exception e)
            {

            }
            return false;
        }
    }
}
