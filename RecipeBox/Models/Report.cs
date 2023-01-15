using RecipeBox.Areas.Data;

namespace RecipeBox.Models
{
    public enum ReportType
    {
        // TODO: Decide on all the types
        // FalseTag, InappropriateContent, FalseReport
    }

    public class Report
    {
        public int Id { get; set; }
        public ReportType ReportType { get; set; }
        public RecipeUser ReportingUser { get; set; } = null!;
        public RecipeUser ReportedUser { get; set; } = null!;
        // TODO: Reported content
        public bool WasReviewed { get; set; }
        public bool WasAccepted { get; set; }
        public RecipeUser Reviewer { get; set; } = null!;
        public DateTime ReviewedDate { get; set; }
    }
}
