using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Funcionario
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        [Required]
        [StringLength(100)]
        public string Cargo {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Admissao {get; set;}

        [Required]
        [Range(0, 9999999999.99)]
        [DataType(DataType.Currency)]
        public decimal Salario {get; set;}

        [Required]
        public bool Status {get; set;}
    }
}







