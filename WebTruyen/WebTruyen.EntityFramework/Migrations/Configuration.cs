namespace WebTruyen.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebTruyen.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<WebTruyen.EntityFramework.WebTruyenDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebTruyen.EntityFramework.WebTruyenDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.QuocGia.AddOrUpdate(x => x.ID,
                new QuocGia() { ID = 1, TenQuocGia = "Nhật Bản" },
                new QuocGia() { ID = 2, TenQuocGia = "Hàn Quốc" },
                new QuocGia() { ID = 3, TenQuocGia = "Mỹ" },
                new QuocGia() { ID = 4, TenQuocGia = "Việt Nam" }
                );
            context.Theloai.AddOrUpdate(x => x.ID,
                new TheLoai() { ID = 1, TenTheLoai = "Adult", MoTa = "Thể loại có đề cập đến vấn đề nhạy cảm, chỉ dành cho tuổi 17+." },
                new TheLoai() { ID = 2, TenTheLoai = "Adventure", MoTa = "Thể loại phiêu lưu, mạo hiểm, thường là hành trình của các nhân vật." },
                new TheLoai() { ID = 3, TenTheLoai = "Anime", MoTa = "Những truyện đã được chuyển thể thành Anime." },
                new TheLoai() { ID = 4, TenTheLoai = "Comedy", MoTa = "Thể loại có nội dung trong sáng và cảm động, thường có các tình tiết gây cười, các xung đột nhẹ nhàng." },
                new TheLoai() { ID = 5, TenTheLoai = "Comic", MoTa = "Truyện tranh Châu Âu và Châu Mĩ." },
                new TheLoai() { ID = 6, TenTheLoai = "Doujinshi", MoTa = "Thể loại truỵện phóng tác do fan hay có thể cả những Mangaka khác với tác giả truyện gốc. Tác giả vẽ Doujinshi thường dựa trên những nhân vật gốc để viết ra những câu chuyện theo sở thích của mình." },
                new TheLoai() { ID = 7, TenTheLoai = "Drama", MoTa = "Thể loại mang đến cho người xem những cảm xúc khác nhau: buồn bã, căng thẳng thậm chí là bi phẫn. " },
                new TheLoai() { ID = 8, TenTheLoai = "Ecchi", MoTa = "Thể loại được xem là ranh giới giữa Hentai và non-Hentai, thường có những tình huống nhạy cảm nhằm lôi cuốn người xem." },
                new TheLoai() { ID = 9, TenTheLoai = "Fantasy", MoTa = "Thể loại xuất phát từ trí tưởng tượng phong phú, từ pháp thuật đến thế giới trong mơ thậm chí là những câu chuyện thần tiên. " },
                new TheLoai() { ID = 10, TenTheLoai = "Gender Bender", MoTa = "Là một thể loại trong đó giới tính của nhân vật bị lẫn lộn: nam hoá thành nữ, nữ hóa thành nam... " },
                new TheLoai() { ID = 11, TenTheLoai = "Harem", MoTa = "Thể loại truyện tình cảm, lãng mạn mà trong đó, nhiều nhân vật nữ thích một nam nhân vật chính. " },
                new TheLoai() { ID = 12, TenTheLoai = "Historical", MoTa = "Thể loại có liên quan đến thời xa xưa. " },
                new TheLoai() { ID = 13, TenTheLoai = "Live action", MoTa = "Truyện đã được chuyển thể thành phim." },
                new TheLoai() { ID = 14, TenTheLoai = "One shot", MoTa = "Những truyện ngắn, thường là 1 chapter." },
                new TheLoai() { ID = 15, TenTheLoai = "Romance", MoTa = "Thường là những câu chuyện về tình yêu. " },
                new TheLoai() { ID = 16, TenTheLoai = "School Life", MoTa = "Trong thể loại này, ngữ cảnh diễn biến câu chuyện chủ yếu ở trường học. " },
                new TheLoai() { ID = 17, TenTheLoai = "Sci-fi", MoTa = "Bao gồm những chuyện khoa học viễn tưởng" },
                new TheLoai() { ID = 18, TenTheLoai = "Sports", MoTa = "Đúng như tên gọi, những môn thể thao như bóng đá, bóng chày, bóng chuyền, đua xe, cầu lông,... là một phần của thể loại này. " }
                );
            context.LoaiTaiKhoans.AddOrUpdate(x => x.ID,
                new LoaiTaiKhoan() { ID=1,TenLoai="Admin"},
                new LoaiTaiKhoan() { ID=2,TenLoai="Tài Khoản Thường"},
                new LoaiTaiKhoan() { ID=3, TenLoai="Tài Khoản Vip"}
                );
            context.TacGia.AddOrUpdate(x => x.ID, 
                new TacGia() {ID=1,TenTacGia="Đang cập nhật",AnhTacGia="images/tacgia/default-tac-gia.jpg", TieuSu=""},
                new TacGia() { ID = 2, TenTacGia = "Fujiko Fujio", AnhTacGia = "images/tacgia/FujikoFujio.jpg", TieuSu = "Fujiko Fujio là bút danh chung của hai tác giả bộ truyện tranh nổi tiếng thế giới Doraemon. Hai nhà văn Fujimoto Hiroshi (bút danh Fujiko F. Fujio) và Abiko Motoo (bút danh Fujiko Fujio (A)) quen biết nhau từ hồi tiểu học và cùng có đam mê vẽ tranh.\n- Đây chính là tác giả của bộ truyện tranh Doraemon - một biểu tượng của văn hóa Nhật Bản ngày nay" },
                new TacGia() { ID = 3, TenTacGia= "Gosho Aoyama",AnhTacGia= "images/tacgia/GoshoAoyama.jpg",TieuSu=""}
                );
            context.TinhTrang.AddOrUpdate(x => x.ID,
                new TinhTrang() { ID=1,TenTinhTrang="Chưa Hoàn Thành"},
                new TinhTrang() { ID = 2, TenTinhTrang = "Hoàn Thành" }
                );
            context.Truyen.AddOrUpdate(x => x.ID ,
                new Truyen() { ID = 1 , Ten = "Alcafus" , TenKhac = "Alcafus" , TenTruyenKhongDau = "Alcafus" , NamPhatHanh = 2019 , SoChuong = 4 , AnhBia = "~/Images/alcafus.jpg" , MoTa = "Shibasaki là một học sinh có tình yêu đối với động vật. Một ngày nọ cậu tình cờ tìm thấy một cô bé người thú bị thương ở ngôi đền gần nhà nên đã giúp cô ấy ... Nhưng cậu ko ngờ rằng nơi đấy chính là cảnh cổng dẫn đến 1 thế giới khác, nơi các cafus chiến đấu lẫn nhau để sinh tồn ..." , Gia = 20000 , NgayDang = DateTime.Now , QuocGiaID = 1 , TinhTrangID = 1 , TacGiaID = 1 } ,
                new Truyen() {ID=2, Ten = "The New Gate" , TenKhac = "The New Gate" , TenTruyenKhongDau = "The-New-Gate" , NamPhatHanh = 2019 , SoChuong = 4 , AnhBia = "~/Images/the_new_gate.jpg" , MoTa = "The New Gate, một trò chơi online bỗng dưng trờ thành trò chơi của tử thần sau khi 10.000 người bị cuốn vào trò chơi.0đầu tiên) đã cứu toàn bộ người chơi sống sót thoát ra.Nhưng sau khi anh đánh bại boss cuối thì lại bị một luồng ánh sáng bí ần hút ngược trở lại game và đưa anh tới thế giới game 500 năm sau." , Gia = 20000 , NgayDang = DateTime.Now , QuocGiaID = 1 , TinhTrangID = 1 , TacGiaID = 1 },
                new Truyen() { ID = 3 , Ten = "ĐẶC THÙ TRUYỀN THUYẾT" , TenKhac = "ĐẶC THÙ TRUYỀN THUYẾT" , TenTruyenKhongDau = "DacThuTruyenThuyet" , NamPhatHanh = 2019 , SoChuong = 4 , AnhBia = "~/Images/dac-thu-truyen-thuyet.jpg" , MoTa = "Chử Minh Dạng là 1 thiếu niên bình thường đến không thể bình thường hơn, nếu có khác thì khác ở chỗ cậu hết sức xui xẻo. Khi mới sinh ra thì bị dây rốn cuốn cổ suýt chết, lớn thì thường xuyên bị các thể loại thương tích kiểu như : ra đường thì bị bảng hiệu rớt trúng, đi học thể dục bị giá bóng rổ đột nhiên đổ đè gãy chân . . . vân vân và mây mây.Rồi trong kỳ thi chuyển cấp , do bị ngộ độc thực phẩm => vào bệnh viện nên cậu thi không đc tốt. . . Sau đó cậu đã điền bừa tên của 1 ngôi trường lạ vào phiếu nguyện vọng . . .Nhưng đó có phải là 1 ngôi trường bình thường hay không?Chử Minh Dạng có thật là người bình thường hay không?Vì sao cậu lại xui xẻo đến thế? Thân thế thật sự của cậu??Biến cố cả ngàn năm về trước???( Ờ rồi, mình viết văn k hay lắm đâu... )" , Gia = 20000 , NgayDang = DateTime.Now , QuocGiaID = 1 , TinhTrangID = 1 , TacGiaID = 1 } 

                );
        }
    }
}
