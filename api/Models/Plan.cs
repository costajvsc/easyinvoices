using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{

    [Table("plans")]
    public partial class Plan
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [MaxLength(25)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [JsonIgnore] 
        public List<Invoice> Invoices { get; set; }
    }
}