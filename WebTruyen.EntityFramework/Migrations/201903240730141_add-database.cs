namespace WebTruyen.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chuong",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ChuongIndex = c.String(),
                        TruyenID = c.Int(nullable: false),
                        TenChuong = c.String(),
                        NgayDang = c.DateTime(nullable: false),
                        NoiDung = c.String(),
                        LuotXem = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Truyen", t => t.TruyenID, cascadeDelete: true)
                .Index(t => t.TruyenID);
            
            CreateTable(
                "dbo.Truyen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        TenKhac = c.String(),
                        TenTruyenKhongDau = c.String(),
                        NamPhatHanh = c.Int(nullable: false),
                        SoChuong = c.Int(nullable: false),
                        AnhBia = c.String(),
                        MoTa = c.String(),
                        TinhTrangID = c.Int(nullable: false),
                        TacGiaID = c.Int(nullable: false),
                        NgayDang = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        QuocGiaID = c.Int(nullable: false),
                        Gia = c.Int(nullable: false),
                        LuotXem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuocGia", t => t.QuocGiaID, cascadeDelete: true)
                .ForeignKey("dbo.TacGia", t => t.TacGiaID, cascadeDelete: true)
                .ForeignKey("dbo.TinhTrang", t => t.TinhTrangID, cascadeDelete: true)
                .Index(t => t.TinhTrangID)
                .Index(t => t.TacGiaID)
                .Index(t => t.QuocGiaID);
            
            CreateTable(
                "dbo.QuocGia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenQuocGia = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTacGia = c.String(),
                        TieuSu = c.String(),
                        AnhTacGia = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TinhTrang",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTinhTrang = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DanhGia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TruyenID = c.Int(nullable: false),
                        Diem = c.Int(nullable: false),
                        NoiDung = c.String(),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Truyen", t => t.TruyenID, cascadeDelete: true)
                .Index(t => t.TruyenID);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TruyenID = c.Int(nullable: false),
                        TaiKhoanID = c.Int(nullable: false),
                        Gia = c.Int(nullable: false),
                        ThoiGianMua = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TaiKhoan", t => t.TaiKhoanID, cascadeDelete: true)
                .ForeignKey("dbo.Truyen", t => t.TruyenID, cascadeDelete: true)
                .Index(t => t.TruyenID)
                .Index(t => t.TaiKhoanID);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTaiKhoan = c.String(),
                        MatKhau = c.String(),
                        HoTen = c.String(),
                        Email = c.String(),
                        Token = c.String(),
                        AnhDaiDien = c.String(),
                        Credit = c.Int(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        IP = c.String(),
                        NgayDangKi = c.DateTime(nullable: false),
                        LoaiTaiKhoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiTaiKhoan", t => t.LoaiTaiKhoanID, cascadeDelete: true)
                .Index(t => t.LoaiTaiKhoanID);
            
            CreateTable(
                "dbo.LoaiTaiKhoan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LichSuNapCredit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaiKhoanID = c.Int(nullable: false),
                        MaThe = c.String(),
                        SoCredit = c.Int(nullable: false),
                        IP = c.String(),
                        ThoiGianNap = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TaiKhoan", t => t.TaiKhoanID, cascadeDelete: true)
                .Index(t => t.TaiKhoanID);
            
            CreateTable(
                "dbo.Loi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TruyenID = c.Int(nullable: false),
                        TenTaiKhoan = c.String(),
                        NoiDung = c.String(),
                        NgayGui = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Truyen", t => t.TruyenID, cascadeDelete: true)
                .Index(t => t.TruyenID);
            
            CreateTable(
                "dbo.TheLoai",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTheLoai = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.YeuThich",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaiKhoanID = c.Int(nullable: false),
                        TruyenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Truyen", t => t.TruyenID, cascadeDelete: true)
                .Index(t => t.TruyenID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YeuThich", "TruyenID", "dbo.Truyen");
            DropForeignKey("dbo.Loi", "TruyenID", "dbo.Truyen");
            DropForeignKey("dbo.LichSuNapCredit", "TaiKhoanID", "dbo.TaiKhoan");
            DropForeignKey("dbo.DonHang", "TruyenID", "dbo.Truyen");
            DropForeignKey("dbo.DonHang", "TaiKhoanID", "dbo.TaiKhoan");
            DropForeignKey("dbo.TaiKhoan", "LoaiTaiKhoanID", "dbo.LoaiTaiKhoan");
            DropForeignKey("dbo.DanhGia", "TruyenID", "dbo.Truyen");
            DropForeignKey("dbo.Chuong", "TruyenID", "dbo.Truyen");
            DropForeignKey("dbo.Truyen", "TinhTrangID", "dbo.TinhTrang");
            DropForeignKey("dbo.Truyen", "TacGiaID", "dbo.TacGia");
            DropForeignKey("dbo.Truyen", "QuocGiaID", "dbo.QuocGia");
            DropIndex("dbo.YeuThich", new[] { "TruyenID" });
            DropIndex("dbo.Loi", new[] { "TruyenID" });
            DropIndex("dbo.LichSuNapCredit", new[] { "TaiKhoanID" });
            DropIndex("dbo.TaiKhoan", new[] { "LoaiTaiKhoanID" });
            DropIndex("dbo.DonHang", new[] { "TaiKhoanID" });
            DropIndex("dbo.DonHang", new[] { "TruyenID" });
            DropIndex("dbo.DanhGia", new[] { "TruyenID" });
            DropIndex("dbo.Truyen", new[] { "QuocGiaID" });
            DropIndex("dbo.Truyen", new[] { "TacGiaID" });
            DropIndex("dbo.Truyen", new[] { "TinhTrangID" });
            DropIndex("dbo.Chuong", new[] { "TruyenID" });
            DropTable("dbo.YeuThich");
            DropTable("dbo.TheLoai");
            DropTable("dbo.Loi");
            DropTable("dbo.LichSuNapCredit");
            DropTable("dbo.LoaiTaiKhoan");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DonHang");
            DropTable("dbo.DanhGia");
            DropTable("dbo.TinhTrang");
            DropTable("dbo.TacGia");
            DropTable("dbo.QuocGia");
            DropTable("dbo.Truyen");
            DropTable("dbo.Chuong");
        }
    }
}
