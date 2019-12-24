using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSnack.Models
{
    [MetadataType(typeof(z_bas_orders_metadata))]
    public partial class z_bas_orders
    {
        private partial class z_bas_orders_metadata
        {
            public int rowid { get; set; }

            [DisplayName("訂單編號")]
            public string mno { get; set; }

            [DisplayName("訂單日期")]
            public string mdate { get; set; }

            [DisplayName("會員帳號")]
            public string userid { get; set; }

            [DisplayName("總價")]
            public Nullable<decimal> totals { get; set; }

            [DisplayName("收件人姓名")]
            [Required]
            public string mReceiver { get; set; }

            [DisplayName("收件人信箱")]
            [Required]
            [EmailAddress]
            public string mEmail { get; set; }

            [DisplayName("收件人地址")]
            [Required]
            public string mAddress { get; set; }

            [DisplayName("備註")]
            public string remark { get; set; }
        }
    }
}