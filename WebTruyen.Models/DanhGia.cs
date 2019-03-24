using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    [Table("DanhGia")]
    public class DanhGia
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TruyenID")]
        public int TruyenID { get; set; }
        [ForeignKey("TruyenID")]
        public Truyen Truyen { get; set; }
        [JsonProperty("Diem")]
        public int Diem { get; set; }
        [JsonProperty("NoiDung")]
        public string NoiDung { get; set;}
        [JsonProperty("IP")]
        public string IP { get; set; }
    }
}