using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    class LoiManager
    {

        public IEnumerable<Loi> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Loi.ToList();
            }
        }
        public Loi LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.Loi.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(Loi Loi)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.Loi.Add(Loi);
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


        public bool Sua(Loi Loi)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        Loi objLoi = context.Loi.SingleOrDefault(x => x.ID == Loi.ID);
                        if ( objLoi == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objLoi = Loi;
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

        public bool Xoa(Loi Loi)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.Loi.Remove(Loi);
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
