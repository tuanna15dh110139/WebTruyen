using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("Loi")]
    public class Loi
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TruyenID")]
        public int TruyenID { get; set; }
        [ForeignKey("TruyenID")]
        public Truyen Truyen { get; set; }
        [JsonProperty("TenTaiKhoan")]
        public string TenTaiKhoan { get; set; }
        [JsonProperty("NoiDung")]
        public string NoiDung { get; set; }
        [JsonProperty("NgayGui")]
        public DateTime NgayGui { get; set; }
        [JsonProperty("TrangThai")]
        public bool TrangThai { get; set; }
    }
}