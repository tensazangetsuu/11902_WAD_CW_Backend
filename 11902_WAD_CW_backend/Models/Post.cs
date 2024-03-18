using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _11902_WAD_CW_backend.Models
{

    public class Post
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }

        // Nullable foreign key
        public int? TagID { get; set; }

        // Navigation property
        [ForeignKey("TagID")]
        public Tag? Tag { get; set; }
    }
}
