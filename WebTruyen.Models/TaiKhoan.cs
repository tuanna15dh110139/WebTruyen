using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebTruyen.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenTaiKhoan")]
        public string TenTaiKhoan { get; set; }
        [JsonProperty("MatKhau")]
        public string MatKhau { get; set; }
        [JsonProperty("HoTen")]
        public string HoTen { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Token")]
        public string Token { get; set; }
        [JsonProperty("AnhDaiDien")]
        public string AnhDaiDien { get; set; }
        [JsonProperty("Credit")]
        public int Credit { get; set; }
        [JsonProperty("GioiTinh")]
        public bool GioiTinh { get; set; }
        [JsonProperty("IP")]
        public string IP { get; set; }
        [JsonProperty("NgayDangKi")]
        public DateTime NgayDangKi { get; set; }
        [JsonProperty("LoaiTaiKhoanID")]
        public int LoaiTaiKhoanID { get; set; }
        [ForeignKey("LoaiTaiKhoanID")]
        public LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}