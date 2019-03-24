using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruyen.Models;

namespace WebTruyen.EntityFramework
{
    class WebTruyenDBContext : DbContext
    {
        public WebTruyenDBContext() : base()
        { }
        public virtual DbSet<Chuong> Chuong { get; set; }
        public virtual DbSet<DanhGia> DanhGia {get;set;}
        public virtual DbSet<DonHang> DonHang {get;set;}
        public virtual DbSet<LichSuNapCredit> LichSuNapCredit {get;set;}
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public virtual DbSet<Loi> Loi { get; set; }
        public virtual DbSet<QuocGia> QuocGia { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TheLoai>Theloai { get; set; }
        public virtual DbSet<TinhTrang> TinhTrang { get; set; }
        public virtual DbSet<Truyen> Truyen { get; set; }
        public virtual DbSet<YeuThich> YeuThich { get; set; }
    }
}
