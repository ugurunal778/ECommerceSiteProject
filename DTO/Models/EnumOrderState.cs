using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTO.Models
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Waiting,
        [Display(Name = "Paketleniyor")]
        InPackage,
        [Display(Name = "Kargolandı")]
        Shipped,
        [Display(Name = "Tamamlandı")]
        Completed
    }
}