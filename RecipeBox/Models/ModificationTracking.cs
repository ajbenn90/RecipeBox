using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
    public class ModificationTracking
    {
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }

        // TODO: Change these to user types
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; } = null!;
        [Display(Name = "Last Modified By")]
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; } = null!;
    }
}
