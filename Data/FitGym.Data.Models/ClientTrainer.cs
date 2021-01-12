namespace FitGym.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ClientTrainer
    {
        [Required]
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        public string TrainerId { get; set; }

        public virtual ApplicationUser Trainer { get; set; }
    }
}
