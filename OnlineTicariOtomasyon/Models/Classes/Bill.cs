using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillOrderNo { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string TaxAdministration { get; set; }


        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryPerson { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Total { get; set; }

        public ICollection<BillNote> BillNotes { get; set; }


    }
}