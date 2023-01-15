using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;

namespace RecipeBox.Areas.Data
{
    public class RecipeUser : IdentityUser
    {
        public bool IsSuspended { get; set; }
        public DateTime? SuspensionEndDate { get; set; }

        // TODO: Food preferences
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Recipe> FavoriteRecipes { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<ReviewVote> ReviewsVotes { get; set; } = null!;
        public DbSet<Report> ReportsWritten { get; set; } = null!;
        public DbSet<Report> ReportsOnUser { get; set; } = null!;
    }
}
