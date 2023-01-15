using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
    public class Review : ModificationTracking
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string? Text { get; set; }

        public Recipe Recipe { get; set; } = null!;
        // TODO: Author FK
        public DbSet<ReviewVote> ReviewVotes { get; set; } = null!;
    }
}
