using RecipeBox.Areas.Data;

namespace RecipeBox.Models
{
    public class ReviewVote
    {
        public int Id { get; set; }
        public bool IsHelpful { get; set; }

        // Navigation properties
        public Review Review { get; set; } = null!;
        public RecipeUser Author { get; set; } = null!;
    }
}
