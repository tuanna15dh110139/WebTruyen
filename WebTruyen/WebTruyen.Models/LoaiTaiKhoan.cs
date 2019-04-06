using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("LoaiTaiKhoan")]
    public class LoaiTaiKhoan
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TenLoai")]
        public string TenLoai { get; set; }
    }
}