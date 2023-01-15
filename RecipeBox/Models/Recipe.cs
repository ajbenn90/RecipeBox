using Microsoft.EntityFrameworkCore;
using RecipeBox.Areas.Data;

namespace RecipeBox.Models
{
    public enum Visibility
    {
        Public, Private
    }

    public class Recipe : ModificationTracking
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ThumbnailFile { get; set; }
        public Visibility Visibility { get; set; }
        public string? Instructions { get; set; }
        public string? Story { get; set; }

        public DbSet<RecipeSection> Sections { get; set; } = null!;
        public RecipeUser Author { get; set; } = null!;
        // Tags - however that's going to work
    }
}
