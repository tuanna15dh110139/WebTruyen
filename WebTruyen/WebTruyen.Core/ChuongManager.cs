using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    class ChuongManager
    {
        public IEnumerable<Chuong> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Chuong.ToList();
            }
        }
        public Chuong LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Chuong.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(Chuong Chuong)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.Chuong.Add(Chuong);
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


        public bool Sua(Chuong Chuong)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        Chuong objChuong = context.Chuong.SingleOrDefault(x => x.ID == Chuong.ID);
                        if ( objChuong == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objChuong.TenChuong = Chuong.TenChuong;
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

        public bool Xoa(Chuong Chuong)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.Chuong.Remove(Chuong);
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
