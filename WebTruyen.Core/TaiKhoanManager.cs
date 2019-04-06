using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class TaiKhoanManager
    {
        /// <summary>
        /// Đăng kí
        /// </summary>
        /// <param name="_taiKhoan"></param>
        /// <returns></returns>
        public bool DangKi(TaiKhoan _taiKhoan)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                if ( context.TaiKhoan.Any(x => x.TenTaiKhoan == _taiKhoan.TenTaiKhoan) )
                    throw new Exception("Tài khoản đã được sử dụng!");
                if ( context.TaiKhoan.Any(x => x.Email == _taiKhoan.Email) )
                    throw new Exception("Email đã được sử dụng!");
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        string hashMatKhau = BCrypt.Net.BCrypt.HashPassword(_taiKhoan.MatKhau);
                        _taiKhoan.MatKhau = hashMatKhau;
                        _taiKhoan.Token = BCrypt.Net.BCrypt.GenerateSalt();
                        _taiKhoan.AnhDaiDien = "~/images/avatar.png";
                        _taiKhoan.LoaiTaiKhoanID = 2;
                        _taiKhoan.NgayDangKi = DateTime.Now;
                        context.TaiKhoan.Add(_taiKhoan);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch ( Exception ex )
                    {
                        transaction.Rollback();
                        throw new Exception(ex.ToString());
                    }
                }

            }
        }
        /// <summary>
        /// Sửa thông tin tài khoản
        /// </summary>
        /// <param name="taiKhoan"></param>
        /// <returns></returns>
        public bool SuaThongTinTaiKhoan(TaiKhoan taiKhoan)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    Models.TaiKhoan objTaiKhoan = context.TaiKhoan.SingleOrDefault(x => x.TenTaiKhoan == taiKhoan.TenTaiKhoan || x.Email == taiKhoan.Email);
                    if ( objTaiKhoan != null )
                    {
                        try
                        {
                            if ( !string.IsNullOrEmpty(taiKhoan.HoTen) )
                                objTaiKhoan.HoTen = taiKhoan.HoTen;
                            if ( !string.IsNullOrEmpty(taiKhoan.AnhDaiDien) )
                                objTaiKhoan.AnhDaiDien = taiKhoan.AnhDaiDien;
                            if ( objTaiKhoan.GioiTinh != taiKhoan.GioiTinh )
                                objTaiKhoan.GioiTinh = taiKhoan.GioiTinh;
                            if ( DateTime.Compare(objTaiKhoan.NgaySinh , taiKhoan.NgaySinh) != 0 )
                                objTaiKhoan.NgaySinh = taiKhoan.NgaySinh;
                            if ( !BCrypt.Net.BCrypt.Verify(taiKhoan.MatKhau , objTaiKhoan.MatKhau) )
                            {
                                string hashMatKhau = BCrypt.Net.BCrypt.HashPassword(taiKhoan.MatKhau);
                                objTaiKhoan.MatKhau = hashMatKhau;

                            }
                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch ( Exception ex )
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
        }


        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="_tenTaiKhoan"></param>
        /// <param name="_matKhau"></param>
        /// <returns></returns>
        public string DangNhap(string _tenTaiKhoan , string _matKhau)
        {
            try
            {
                using ( WebTruyenDBContext context = new WebTruyenDBContext() )
                {
                    var taikhoan = context.TaiKhoan.FirstOrDefault(x => x.TenTaiKhoan == _tenTaiKhoan);
                    if ( taikhoan != null )
                        if ( BCrypt.Net.BCrypt.Verify(_matKhau , taikhoan.MatKhau.ToString()) )
                            return taikhoan.Token;
                    return null;

                }
            }
            catch ( Exception ex )
            {
                return null;
            }
        }
        /// <summary>
        /// Quên mật khẩu
        /// </summary>
        /// <param name="taiKhoan"></param>
        /// <returns></returns>
        public string QuenMatKhau(string taiKhoan)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                if ( !context.TaiKhoan.Any(x => x.TenTaiKhoan == taiKhoan) || !context.TaiKhoan.Any(x => x.TenTaiKhoan == taiKhoan) )
                    throw new Exception("Tài khoản không tồn tại!");
                else
                {
                    Random rd = new Random();
                    string OTP = string.Empty;
                    TaiKhoan objTaiKhoan = context.TaiKhoan.SingleOrDefault(x => x.TenTaiKhoan == taiKhoan || x.Email == taiKhoan);
                    using ( var transaction = context.Database.BeginTransaction() )
                    {
                        try
                        {
                            OTP = rd.Next(100000 , 999999).ToString();
                            objTaiKhoan.OTP = OTP;
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch ( Exception e )
                        {
                            transaction.Rollback();
                            return OTP;
                        }
                    }
                    return OTP;

                }
            }
        }
        /// <summary>
        /// Đổi mật khẩu có otp
        /// </summary>
        /// <param name="taikhoan"></param>
        /// <param name="otp"></param>
        /// <param name="matkhaumoi"></param>
        /// <returns></returns>
        public bool DoiMatKhau(string taikhoan , string otp , string matkhaumoi)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                if ( !context.TaiKhoan.Any(x => x.TenTaiKhoan == taikhoan) || !context.TaiKhoan.Any(x => x.OTP == otp) )
                    throw new Exception("Tài khoản không tồn tại hoặc OTP không đúng!");
                TaiKhoan objTaiKhoan = context.TaiKhoan.FirstOrDefault(x => x.TenTaiKhoan == taikhoan && x.OTP == otp);
                if ( objTaiKhoan != null )
                {
                    using ( var transaction = context.Database.BeginTransaction() )
                    {
                        try
                        {
                            string hashMatKhau = BCrypt.Net.BCrypt.HashPassword(matkhaumoi);
                            objTaiKhoan.MatKhau = hashMatKhau;
                            objTaiKhoan.Token = BCrypt.Net.BCrypt.GenerateSalt();
                            objTaiKhoan.OTP = string.Empty;
                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch ( Exception e )
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }

                }

            }
            return false;
        }

        /// <summary>
        /// Lấy thông tin tài khoảng bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaiKhoan LayThongTinTaiKhoan(int id)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TaiKhoan.FirstOrDefault(x => x.ID == id);
            }
        }
        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaiKhoan> LayDanhSachTaiKhoan()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TaiKhoan.ToList();
            }
        }

    }
}
