using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("QuocGia")]
    public class QuocGia
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenQuocGia")]
        public string TenQuocGia { get; set; }
    }
}