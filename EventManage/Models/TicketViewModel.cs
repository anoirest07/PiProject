using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManage.Models
{
    public class TicketViewModel
    {
        public int IdTicket { get; set; }
        public float Prix { get; set; }
        public Evenement Evenement { get; set; }
        public string Logo { get; set; }
        public int IdEvent { get; set; }
        public virtual ICollection<Participant> ParticipantAchat { get; set; }
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