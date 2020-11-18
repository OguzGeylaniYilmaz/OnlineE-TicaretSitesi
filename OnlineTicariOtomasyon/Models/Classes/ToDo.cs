﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}