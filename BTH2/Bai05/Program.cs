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
            Console.WriteLine("--- Cong Ty Dia Oc Dai Phu ---");
            cCongTyDiaOcDaiPhu congTy = new cCongTyDiaOcDaiPhu();
            congTy.NhapDanhSach();
            congTy.XuatTongGiaBan();
            congTy.XuatKhuDatVaNhaPhoDacBiet();
            congTy.TimKiemVaXuat();
        }
    }
}
