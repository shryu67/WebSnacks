using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSnack.Models
{
    [MetadataType(typeof(z_bas_goods_metadata))]
    public partial class z_bas_goods
    {
        private partial class z_bas_goods_metadata
        {
            public int rowid { get; set; }

            [DisplayName("商品編號")]
            public string mno { get; set; }

            [DisplayName("商品名稱")]
            public string mname { get; set; }
            public string mtype { get; set; }
            public string mspec { get; set; }
            public Nullable<System.DateTime> mdate { get; set; }

            [DisplayName("商品圖示")]
            public string mimg { get; set; }
            public Nullable<decimal> qty_stock { get; set; }

            [DisplayName("商品單價")]
            public Nullable<decimal> price_sale { get; set; }
            public Nullable<decimal> price_discount { get; set; }
            public Nullable<decimal> price_cost { get; set; }
            public string remark { get; set; }
        }
    }
}