using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class TheLoaiManager
    {

        public IEnumerable<TheLoai> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Theloai.ToList();
            }
        }
        public TheLoai LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Theloai.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(TheLoai TheLoai)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.Theloai.Add(TheLoai);
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
        }


        public bool Sua(TheLoai TheLoai)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        TheLoai objTheLoai = context.Theloai.SingleOrDefault(x => x.ID == TheLoai.ID);
                        if ( objTheLoai == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objTheLoai.TenTheLoai = TheLoai.TenTheLoai;
                            objTheLoai.MoTa = TheLoai.MoTa;
                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                    }
                    catch ( Exception ex )
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Xoa(TheLoai TheLoai)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.Theloai.Remove(TheLoai);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }
}
