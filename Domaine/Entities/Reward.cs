using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Reward
    {
        [Key]
        public int RewardId { get; set; }
        public string description1 { get; set; }
        public int firstReward { get; set; }
        public string description2 { get; set; }
        public int SecondReward { get; set; }
        public string description3 { get; set; }
        public int ThirdReward { get; set; }
        public int EventId { get; set; }
        public Evenement Event { get; set; }
        public int UserId { get; set; }

        public virtual Organizer Organizer { get; set; }

    }
}
