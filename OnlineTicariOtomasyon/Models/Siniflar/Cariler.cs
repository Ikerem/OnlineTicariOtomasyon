using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CarilerId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girebilirsiniz!")]
        public string CarilerAd { get; set; }

        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Boş Bırakamazsınız!")]
        public string CarilerSoyad { get; set; }

       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CarilerSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CarilMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public  string CariSifre { get; set; }

        public bool Durum { get; set; } 
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}