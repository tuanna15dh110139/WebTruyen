using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    [Table("Chuong")]
    public class Chuong
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("ChuongIndex")]
        public string ChuongIndex { get; set; }
        [JsonProperty("TruyenID")]
        public int TruyenID { get; set; }
        public Truyen Truyen { get; set; }
        [JsonProperty("TenChuong")]
        public string TenChuong { get; set; }
        [JsonProperty("NgayDang")]
        public DateTime NgayDang { get; set; }
        [JsonProperty("NoiDung")]
        public string NoiDung { get; set; }
        [JsonProperty("LuotXem")]
        public string LuotXem { get; set; }
    }
}