using System.ComponentModel.DataAnnotations;

namespace Infra.Entities
{
    public class Person : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        public string? Rg { get; set; }

        [Required(ErrorMessage = "Cpf obrigatorio")]
        [MaxLength(11, ErrorMessage = "Cpf incorreto")]
        [MinLength(11, ErrorMessage = "Cpf incorreto")]
        public string? TaxNumber { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public string? Number { get; set; }
    }
}
