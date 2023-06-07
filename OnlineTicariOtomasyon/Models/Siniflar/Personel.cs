using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Personelad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Personel Soyadı")]
        public string PersonelSoyad { get; set;}
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Görseli")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }    
        public virtual Departman Departman { get; set; }
    }
}