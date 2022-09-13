using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.Client
{
    public class ClientCreateDTO
    {
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
