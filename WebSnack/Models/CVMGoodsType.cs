using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSnack.Models
{
    public class CVMGoodsType
    {
        public List<z_bas_goods_type> gtype { get; set; }
        public List<z_bas_goods> goods { get; set; }
    }
}