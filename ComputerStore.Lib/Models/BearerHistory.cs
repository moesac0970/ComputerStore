namespace ComputerStore.Lib.Models
{
    public class BearerHistory : EntityBase
    {
        public string BearerToken { get; set; }


        // relations
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
