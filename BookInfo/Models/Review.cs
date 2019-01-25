namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; } // PK
        public string ReviewText { get; set; }
        public AppUser Member { get; set; }
    }
}