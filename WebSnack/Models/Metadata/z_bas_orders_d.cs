using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSnack.Models
{
    [MetadataType(typeof(z_bas_orders_d_metadata))]
    public partial class z_bas_orders_d
    {
        private partial class z_bas_orders_d_metadata
        {
            public int rowid { get; set; }

            [DisplayName("訂單編號")]
            public string mno { get; set; }

            [DisplayName("會員帳號")]
            public string userid { get; set; }

            [DisplayName("商品編號")]
            public string gno { get; set; }

            [DisplayName("商品名稱")]
            public string gname { get; set; }

            [DisplayName("單價")]
            public Nullable<decimal> price { get; set; }

            [DisplayName("訂購數量")]
            public Nullable<decimal> qty { get; set; }
            public Nullable<decimal> amounts { get; set; }
            public string remark { get; set; }

            [DisplayName("是否為訂單")]
            public string mIsApproved { get; set; }
        }
    }
}