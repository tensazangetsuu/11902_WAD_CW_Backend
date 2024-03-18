using System.ComponentModel.DataAnnotations;

namespace _11902_WAD_CW_backend.Models
{
    public class Tag
    {
        public int ID { get; set; }
        private string _title;
        [Required(ErrorMessage = "Name is required")]
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tag title cannot be null or empty.");
                }

                _title = value;
            }
        }
    }
}
