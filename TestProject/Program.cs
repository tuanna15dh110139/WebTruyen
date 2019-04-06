using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.Core;
using WebTruyen.Core;
using WebTruyen.Models;
namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Console.WriteLine(QuenMatKhau())*/;
            Console.WriteLine(new TaiKhoanManager().LayDanhSachTaiKhoan().ToString());
            Console.ReadKey();
        }
        static async Task DangKi()
        {

            TaiKhoanManager taiKhoan = new TaiKhoanManager();
            TaiKhoan _taikhoan = new TaiKhoan();
            _taikhoan.TenTaiKhoan = "admin";
            _taikhoan.MatKhau = "admin";
           
            _taikhoan.Email = "admin@gmail.com";
            _taikhoan.GioiTinh = true;
            _taikhoan.HoTen = "admin";
            try
            {

                taiKhoan.DangKi(_taikhoan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static string DangNhap()
        {
            TaiKhoanManager taiKhoanManager = new TaiKhoanManager();
            return taiKhoanManager.DangNhap("admin", "admin");
        }
        static string QuenMatKhau()
        {
            TaiKhoanManager taiKhoanManager = new TaiKhoanManager();
            return taiKhoanManager.QuenMatKhau("admin");
        }
        static bool DoiMatKhau()
        {
            TaiKhoanManager taiKhoanManager = new TaiKhoanManager();
            return taiKhoanManager.DoiMatKhau("admin" , "582722" , "admin2");
        }
        static bool SuaThongTinTaiKhoan()
        {

            TaiKhoan _taikhoan = new TaiKhoan();
            _taikhoan.TenTaiKhoan = "admin";
            _taikhoan.MatKhau = "admin2";
            _taikhoan.Email = "admin@gmail.com";
            _taikhoan.GioiTinh = false;
            _taikhoan.HoTen = "admin2";
            _taikhoan.NgaySinh = DateTime.Now;
            TaiKhoanManager taiKhoanManager = new TaiKhoanManager();
          return  taiKhoanManager.SuaThongTinTaiKhoan(_taikhoan);

        }

    }
}
