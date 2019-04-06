using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class QuocGiaManager
    {
        public IEnumerable<QuocGia> LayDanhSach()
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return  context.QuocGia.ToList();
            }
        }
        public QuocGia LayChiTiet(int ID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                return context.QuocGia.FirstOrDefault(x => x.ID == ID);
            }

        }
        public bool Them(QuocGia QuocGia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.QuocGia.Add(QuocGia);
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

 
        public bool Sua(QuocGia QuocGia)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        QuocGia objQuocGia = context.QuocGia.SingleOrDefault(x => x.ID == QuocGia.ID);
                        if ( objQuocGia == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objQuocGia.TenQuocGia = QuocGia.TenQuocGia;
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

        public bool Xoa(QuocGia QuocGia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.QuocGia.Remove(QuocGia);
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
