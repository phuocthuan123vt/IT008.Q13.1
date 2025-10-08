using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai01
{
    class Program
    {
        static int TinhTongSoLe(int[] A)
        {
            int Sum = 0;
            foreach (int N in A)
                if (N % 2 != 0)
                    Sum += N;
            return Sum;
        }
        static bool LaSoNguyenTo(int N)
        {
            if (N <= 1) return false;
            for(int i = 2; i <= Math.Sqrt(N); i++)
                if (N % i == 0)
                    return false;
            return true;
        }

        static int DemSoNguyenTo(int[] A)
        {
            int Count = 0;
            foreach (int N in A)
                if (LaSoNguyenTo(N))
                    Count++;
            return Count;
        }
        static bool LaSoChinhPhuong(int N)
        {
            int i = (int)Math.Sqrt(N);
            if(i*i != N) return false;
            return true;
        }

        static int TimSoChinhPhuongMin(int[] A)
        {
            int Min = int.MaxValue;
            int t = Min;
            foreach (int N in A)
                if ( LaSoChinhPhuong(N) && N < Min )
                    Min = N;
            if (Min == t)
                return -1;
            return Min;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang: ");
            int N = int.Parse(Console.ReadLine());
            int [] A = new int[N];
            Random rnd = new Random(); 
            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next(1, 100);
            }
            Console.WriteLine("Cac phan tu trong mang: ");
            foreach (int n in A)
                Console.Write(n + " ");
            Console.WriteLine();
            Console.WriteLine("Tong cac so le trong mang: " + TinhTongSoLe(A));
            Console.WriteLine("So luong so nguyen to trong mang: " + DemSoNguyenTo(A));
            if (TimSoChinhPhuongMin(A) == -1)
                Console.WriteLine("Mang khong co so chinh phuong");
            else
                Console.WriteLine("So chinh phuong nho nhat trong mang la: " + TimSoChinhPhuongMin(A));
        }
    }
}
