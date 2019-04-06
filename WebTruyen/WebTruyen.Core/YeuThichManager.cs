using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
   public class YeuThichManager
    {
        public IEnumerable<YeuThich> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.YeuThich.ToList();
            }
        }
        public YeuThich LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.YeuThich.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(YeuThich YeuThich)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.YeuThich.Add(YeuThich);
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


        public bool Sua(YeuThich YeuThich)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        YeuThich objYeuThich = context.YeuThich.SingleOrDefault(x => x.ID == YeuThich.ID);
                        if ( objYeuThich == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objYeuThich = YeuThich; 
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

        public bool Xoa(YeuThich YeuThich)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.YeuThich.Remove(YeuThich);
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
