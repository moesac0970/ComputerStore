using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Lib.Models
{
    public class Message : EntityBase
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
