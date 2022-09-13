using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string LastName { get; set; }

        [Required]
        public string Direccion { get; set; }

    }
}
