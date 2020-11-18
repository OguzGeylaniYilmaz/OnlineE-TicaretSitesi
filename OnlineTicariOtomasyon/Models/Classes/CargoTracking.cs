﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Statement { get; set; }

        public DateTime DateTime { get; set; }
    }
}