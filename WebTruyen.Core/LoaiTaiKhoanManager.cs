using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class LoaiTaiKhoanManager
    {
        public bool Them(LoaiTaiKhoan loaiTaiKhoan)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.LoaiTaiKhoans.Add(loaiTaiKhoan);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Sua(LoaiTaiKhoan loaiTaiKhoan)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    LoaiTaiKhoan _loaiTaiKhoan = context.LoaiTaiKhoans.FirstOrDefault(x => x.ID == loaiTaiKhoan.ID);
                    if ( _loaiTaiKhoan == null )
                        throw new Exception("Loại tài khoản không tồn tại!");

                    _loaiTaiKhoan.TenLoai = loaiTaiKhoan.TenLoai;
                    context.SaveChanges();
                    return true;
                }
                catch ( Exception ex )
                {
                    return false;
                }

            }


        }

        public bool Xoa(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    IEnumerable<TaiKhoan> taiKhoan = context.TaiKhoan.Where(x => x.LoaiTaiKhoanID == ID);
                    context.TaiKhoan.RemoveRange(taiKhoan);
                    LoaiTaiKhoan _loaiTaiKhoan = context.LoaiTaiKhoans.FirstOrDefault(x => x.ID == ID);
                    context.LoaiTaiKhoans.Remove(_loaiTaiKhoan);
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IEnumerable<LoaiTaiKhoan> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.LoaiTaiKhoans.ToList();
            }
        }

        public LoaiTaiKhoan LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                LoaiTaiKhoan loaiTaiKhoan = context.LoaiTaiKhoans.FirstOrDefault(x => x.ID == ID);
                return loaiTaiKhoan;
            }
        }
    }

}
