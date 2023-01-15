namespace RecipeBox.Models
{
    public enum Measurement
    {
        Tsp, Tbsp, FlOz, Cup, Pint, Quart, Gallon, Lb, Oz
    }

    public class RecipeIngredient
    {
        public int Id { get; set; }
        public string Ingredient { get; set; } = null!;
        public float Amount { get; set; }
        public Measurement Measurement { get; set; }
        // For exampe, "sliced thinly"
        public string? Attribute { get; set; }

        public RecipeSection Recipe { get; set; } = null!;
    }
}
