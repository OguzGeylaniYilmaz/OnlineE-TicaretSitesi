using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(200)]
        public string Statement { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Staff { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Recipient { get; set; }

        public DateTime Date { get; set; }
    }
}