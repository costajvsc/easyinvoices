using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    [Table("customers")]
    public partial class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório")]
        [MaxLength(50)]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório")]
        [MaxLength(50)]
        public string FantasyName { get; set; }

        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo Nome do Responsável é obrigatório")]
        public string AgentName { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress]
        public string AgentEmail { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }
        

        [JsonIgnore] 
        public List<Invoice> Invoices { get; set; }
    }
}
    