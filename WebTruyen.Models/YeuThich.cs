using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WebTruyen.Models
{
    [Table("YeuThich")]
   public class YeuThich
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("TaiKhoanID")]
        public int TaiKhoanID { get; set; }
        [JsonProperty("TruyenID")]
        public int TruyenID { get; set; }
        [ForeignKey("TruyenID")]
        public Truyen Truyen { get; set; }
    }
}
