namespace DSCC.API.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Genre { get; set; }

    }
}
