using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebTruyen.Models
{
    [Table("TheLoai")]
    public class TheLoai
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenTheLoai")]
        public string TenTheLoai { get; set; }
        [JsonProperty("MoTa")]
        public string MoTa { get; set; }

    }
}