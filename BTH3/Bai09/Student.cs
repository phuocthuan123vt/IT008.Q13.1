using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai09
{
    class Student
    {
        public int STT {  get; set; }
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Major { get; set; }
        public string Gender { get; set; }
        public HashSet<string> RegisteredSubject { get; set; }
        public Student()
        {
            RegisteredSubject = new HashSet<string>();
        }
        public string RegisteredSubjectsDisplay
        {
            get
            {
                
                if (RegisteredSubject == null || RegisteredSubject.Count == 0)
                {
                    return "0";
                }
                string result = RegisteredSubject.Count.ToString() + ": ";
                return result + string.Join(", ", RegisteredSubject);
            }
        }

    }
}
