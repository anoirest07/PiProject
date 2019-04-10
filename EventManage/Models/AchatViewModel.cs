using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class AchatViewModel
    {
        public int IdAchat { get; set; }

        public int Quantites { get; set; }

        public int IdTicket { get; set; }
        
        public int IdParticipant { get; set; }
        public Ticket Tickets { get; set; }
        public Participant Participant { get; set; }
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