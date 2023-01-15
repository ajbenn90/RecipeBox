using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Areas.Data;
using RecipeBox.Models;

namespace RecipeBox.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public DbSet<RecipeSection> RecipeSections { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
        public DbSet<ReviewVote> ReviewVotes { get; set; } = null!;
        public DbSet<Follow> Follows { get; set; } = null!;

        // Db seeding
        public async Task InitializeDb(UserManager<RecipeUser> um, RoleManager<IdentityRole> rm)
        {
            Database.Migrate();

            if (!rm.Roles.Any())
            {
                await rm.CreateAsync(new IdentityRole("Admin"));
                await rm.CreateAsync(new IdentityRole("Moderator"));
            }

            if (!um.Users.Any())
            {
                await CreateUser(um, "The Firelord", "ajbenn30@gmail.com", "Admin");
                await CreateUser(um, "jortan", "fakeemail@null.com", "Admin");
                await CreateUser(um, "Moderator 1", "tier3sub@iono.com", "Moderator");
                await CreateUser(um, "Giovanni Potage", "extremelycooldude47@bonsaiblasters.com", null, true, new DateTime(2023, 2, 13));
                await CreateUser(um, "Bear Trap", "mollyb@blyndefftoyemporium.com");
                await CreateUser(um, "Car Crash", "fredd@bonsaiblasters.com");
                await CreateUser(um, "Ben", "ben@bonsaiblasters.com");
            }

            if (!Follows.Any())
            {
                await AddFollow(um, "The Firelord", "Giovanni Potage", new DateTime(2022, 3, 25));
                await AddFollow(um, "Giovanni Potage", "Bear Trap", new DateTime(2023, 11, 1));
                await AddFollow(um, "Bear Trap", "Giovanni Potage", new DateTime(2023, 12, 1));
                await AddFollow(um, "Giovanni Potage", "Car Crash", new DateTime(2022, 9, 13));
                await AddFollow(um, "Car Crash", "Giovanni Potage", new DateTime(2022, 9, 13));
                await AddFollow(um, "Giovanni Potage", "Ben", new DateTime(2022, 9, 11));
                await AddFollow(um, "Ben", "Giovanni Potage", new DateTime(2022, 9, 11));
                await SaveChangesAsync();
            }

            if (!Recipes.Any())
            {

            }
        }

        private static async Task CreateUser(UserManager<RecipeUser> um, string username, string email, string? role = null, bool isSuspended = false, DateTime? suspensionEnd = null, string password = "123ABC!@#def")
        {
            RecipeUser user = new()
            {
                UserName = username,
                Email = email,
                IsSuspended = isSuspended,
                SuspensionEndDate = suspensionEnd
            };
            await um.CreateAsync(user, password);
            if (role != null)
                await um.AddToRoleAsync(user, role);
        }

        /// <summary>
        /// Adds follow. Does NOT save changes.
        /// </summary>
        /// <param name="um"></param>
        /// <param name="followerUsername"></param>
        /// <param name="followingUsername"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private async Task AddFollow(UserManager<RecipeUser> um, string followerUsername, string followingUsername, DateTime startDate)
        {
            RecipeUser follower = um.Users.Where(u => u.UserName == followerUsername).First();
            RecipeUser following = um.Users.Where(u => u.UserName == followingUsername).First();
            Follow follow = new()
            {
                Follower = follower,
                Following = following,
                StartDate = startDate
            };
            await Follows.AddAsync(follow);
        }

        /// <summary>
        /// Creates the ingredients table from the given txt file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private async Task CreateIngredientsTable(string filepath)
        {
            
        }

        private async Task CreateRecipeSection(List<Ingredient> ingredients, List<float> amounts, List<Measurement> units)
        {

        }

        private async Task AddRecipe(UserManager<RecipeUser> um, string name, string authorUsername, List<RecipeSection> sections, string instructions, Visibility visibility = Visibility.Public, string? story = null)
        {
            Recipe recipe = new()
            {
                Name = name,
                Author = um.Users.Where(u => u.UserName == authorUsername).First(),
                Instructions = instructions,
                Visibility = visibility,
                Story = story
            };
            await RecipeSections.AddRangeAsync(sections);
            for (int i = 0; i < sections.Count; i++)
                recipe.Sections.Add(sections[i]);

            await Recipes.AddAsync(recipe);
        }
    }
}
