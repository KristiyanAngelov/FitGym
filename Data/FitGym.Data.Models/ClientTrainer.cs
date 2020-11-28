namespace FitGym.Data.Models
{
    using System;

    using FitGym.Data.Common.Models;

    public class ClientTrainer
    {
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        public string TrainerId { get; set; }

        public virtual ApplicationUser Trainer { get; set; }
    }
}
