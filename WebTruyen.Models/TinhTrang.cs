using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("TinhTrang")]
    public class TinhTrang
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenTinhTrang")]
        public string TenTinhTrang { get; set; }
    }
}