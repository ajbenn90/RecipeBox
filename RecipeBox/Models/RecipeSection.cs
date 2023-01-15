using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
    public class RecipeSection : ModificationTracking
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }

        public Recipe Recipe { get; set; } = null!;
        public DbSet<RecipeIngredient> Ingredients { get; set; } = null!;
    }
}
