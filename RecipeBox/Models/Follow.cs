using RecipeBox.Areas.Data;

namespace RecipeBox.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public RecipeUser Follower { get; set; } = null!;
        public RecipeUser Following { get; set; } = null!;
        public DateTime StartDate { get; set; }
    }
}
