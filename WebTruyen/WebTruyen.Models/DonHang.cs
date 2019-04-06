using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TruyenID")]
        public int TruyenID { get; set; }
        public Truyen Truyen { get; set; }
        [JsonProperty("TaiKhoanID")]
        public int TaiKhoanID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        [JsonProperty("Gia")]
        public int Gia { get; set; }
        [JsonProperty("ThoiGianMua")]
        public DateTime ThoiGianMua { get; set; }
    }
}