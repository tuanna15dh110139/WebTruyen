using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("LichSuNapCredit")]
    public class LichSuNapCredit
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TaiKhoanID")]
        public int TaiKhoanID { get; set; }
        [ForeignKey("TaiKhoanID")]
        public TaiKhoan TaiKhoan { get; set; }
        [JsonProperty("MaThe")]
        public string MaThe { get; set; }
        [JsonProperty("SoCredit")]
        public int SoCredit { get; set; }
        [JsonProperty("IP")]
        public string IP { get; set; }
        [JsonProperty("ThoiGianNap")]
        public DateTime ThoiGianNap { get; set; }
        [JsonProperty("TrangThai")]
        public bool TrangThai { get; set; }
    }
}