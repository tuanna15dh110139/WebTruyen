using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Core
{
    public class DanhGiaManager
    {

        public bool Them(DanhGia danhgia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        context.DanhGia.Add(danhgia);
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

        public IEnumerable<DanhGia> LayDanhSach(int TruyenID)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {

                try
                {
                    var result = context.DanhGia.Where(x => x.TruyenID == TruyenID);
                    return result;
                }
                catch ( Exception ex )
                {
                    return null;
                }
            }
        }
        public bool Sua(DanhGia danhgia)
        {

            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                using ( var transaction = context.Database.BeginTransaction() )
                {
                    try
                    {
                        DanhGia objDanhGia = context.DanhGia.SingleOrDefault(x => x.ID == danhgia.ID);
                        if ( objDanhGia == null )
                            throw new Exception("Không tìm thấy!");
                        else
                        {
                            objDanhGia.NoiDung = danhgia.NoiDung;
                            objDanhGia.Diem = danhgia.Diem;
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

        public bool Xoa(DanhGia danhgia)
        {
            using ( WebTruyenDBContext context = new WebTruyenDBContext() )
            {
                try
                {
                    context.DanhGia.Remove(danhgia);
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
