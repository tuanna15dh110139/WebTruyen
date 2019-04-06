using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class TinhTrangManager
    {
        public IEnumerable<TinhTrang> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TinhTrang.ToList();
            }
        }
        public TinhTrang LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.TinhTrang.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(TinhTrang TinhTrang)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.TinhTrang.Add(TinhTrang);
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


        public bool Sua(TinhTrang TinhTrang)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        TinhTrang objTinhTrang = context.TinhTrang.SingleOrDefault(x => x.ID == TinhTrang.ID);
                        if ( objTinhTrang == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objTinhTrang.TenTinhTrang = TinhTrang.TenTinhTrang;
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

        public bool Xoa(TinhTrang TinhTrang)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.TinhTrang.Remove(TinhTrang);
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
