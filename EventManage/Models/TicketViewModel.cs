using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class TicketViewModel
    {
        public class CustomViewModel
        {
            public string StripePublishableKey { get; set; }
            public string StripeToken { get; set; }
            public string StripeEmail { get; set; }
            public bool PaymentForHidden { get; set; }
            public string PaymentForHiddenCss
            {
                get
                {
                    return PaymentForHidden ? "hidden" : "";
                }
            }
        }
        public class ChargeViewModel
        {
            public string StripeToken { get; set; }
            public string StripeEmail { get; set; }
        }
    }
}