using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{

    [Table("plans")]
    public partial class Plan
    {
        [Key]
        public int IdPlan { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [MaxLength(25)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
    }
}