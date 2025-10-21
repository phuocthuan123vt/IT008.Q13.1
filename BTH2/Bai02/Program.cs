using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap duong dan thu muc: ");
            string path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Duong dan khong hop le vui long nhap lai!");
                Console.Write("Nhap duong dan thu muc: ");
                path = Console.ReadLine();
            }
            Console.WriteLine("\nDanh sach thu muc va tap tin:");
            ShowDir(path);
        }

        static void ShowDir(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (string d in dirs)
            {
                Console.WriteLine("[DIR] " + d);
                ShowDir(d);
            }
            string[] files = Directory.GetFiles(path);
            foreach (string f in files)
            {
                Console.WriteLine("     " + f);
            }
        }
    }
}
