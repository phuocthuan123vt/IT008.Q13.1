using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            int ngay, thang, nam;

            Console.Write("Nhap ngay: ");
            ngay = int.Parse(Console.ReadLine());

            Console.Write("Nhap thang: ");
            thang = int.Parse(Console.ReadLine());

            Console.Write("Nhap nam: ");
            nam = int.Parse(Console.ReadLine());

            try
            {
                DateTime dt = new DateTime(nam, thang, ngay);

                string thu = "";

                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Sunday: thu = "Chu nhat"; break;
                    case DayOfWeek.Monday: thu = "Thu hai"; break;
                    case DayOfWeek.Tuesday: thu = "Thu ba"; break;
                    case DayOfWeek.Wednesday: thu = "Thu tu"; break;
                    case DayOfWeek.Thursday: thu = "Thu nam"; break;
                    case DayOfWeek.Friday: thu = "Thu sau"; break;
                    case DayOfWeek.Saturday: thu = "Thu bay"; break;
                }

                Console.WriteLine("Ngay {0}/{1}/{2} la {3}.", ngay, thang, nam, thu);
            }
            catch
            {
                Console.WriteLine("Ngay thang nam khong hop le");
            }

            Console.ReadKey();
        }
    }
}
