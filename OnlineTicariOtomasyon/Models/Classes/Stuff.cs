using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Stuff
    {
        [Key]
        public int StaffID { get; set; }

        [Display(Name = "Staff Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string StaffName { get; set; }

        [Display(Name = "Staff Surname")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string StuffSurname { get; set; }

        [Display(Name ="Stuff Image")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string StuffImage { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}