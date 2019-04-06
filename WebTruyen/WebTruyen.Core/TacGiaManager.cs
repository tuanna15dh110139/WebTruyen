using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
   public class TacGiaManager
    {
        public IEnumerable<TacGia> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TacGia.ToList();
            }
        }
        public TacGia LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TacGia.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(TacGia TacGia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.TacGia.Add(TacGia);
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


        public bool Sua(TacGia TacGia)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        TacGia objTacGia = context.TacGia.SingleOrDefault(x => x.ID == TacGia.ID);
                        if ( objTacGia == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objTacGia.TenTacGia = TacGia.TenTacGia;
                            objTacGia.TieuSu = TacGia.TieuSu;
                            objTacGia.AnhTacGia = TacGia.AnhTacGia;
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

        public bool Xoa(TacGia TacGia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.TacGia.Remove(TacGia);
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
