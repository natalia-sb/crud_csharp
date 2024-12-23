using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Ferias
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [ForeignKey("Funcionario")]
        public int FuncionarioId {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataTermino {get; set;}

        [Required]
        [StringLength(20)]
        public string Status {get; set;}


        public Funcionario Funcionario {get; set;}
    }
}
