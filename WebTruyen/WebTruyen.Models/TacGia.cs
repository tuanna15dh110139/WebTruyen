using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("TacGia")]
    public class TacGia
    {

        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenTacGia")]
        public string TenTacGia { get; set; }
        [JsonProperty("TieuSu")]
        public string TieuSu { get; set; }
        [JsonProperty("AnhTacGia")]
        public string AnhTacGia { get; set; }

    }
}