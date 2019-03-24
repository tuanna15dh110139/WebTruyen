using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("Truyen")]
    public class Truyen
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Ten")]
        public string Ten { get; set; }
        [JsonProperty("TenKhac")]
        public string TenKhac { get; set; }
        [JsonProperty("TenTruyenKhongDau")]
        public string TenTruyenKhongDau { get; set; }
        [JsonProperty("TheLoai")]
        public IEnumerable<string> TheLoai { get; set; }
        [JsonProperty("NamPhatHanh")]
        public int NamPhatHanh { get; set; }
        [JsonProperty("SoChuong")]
        public int SoChuong { get; set; }
        [JsonProperty("AnhBia")]
        public string AnhBia { get; set; }
        [JsonProperty("MoTa")]
        public string MoTa { get; set; }
        [JsonProperty("TinhTrangID")]
        public int TinhTrangID { get; set; }
        [ForeignKey("TinhTrangID")]
        public TinhTrang TinhTrang { get; set; }
        [JsonProperty("TacGiaID")]
        public int TacGiaID { get; set; }
        [ForeignKey("TacGiaID")]
        public TacGia TacGia { get; set; }
        [JsonProperty("NgayDang")]
        public DateTime NgayDang { get; set; }
        [JsonProperty("TrangThai")]
        public bool TrangThai { get; set; }
        [JsonProperty("QuocGiaID")]
        public int QuocGiaID { get; set; }
        [ForeignKey("QuocGiaID")]
        public QuocGia QuocGia { get; set; }
        [JsonProperty("Gia")]
        public int Gia { get; set; }
        [JsonProperty("LuotXem")]
        public int LuotXem { get; set; }

    }
}