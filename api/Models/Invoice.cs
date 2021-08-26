using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("invoices")]
    public partial class Invoice 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Data de Contratação é obrigatório.")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "O campo Método de cobrança é Obrigatório")]
        public string BillingMethod { get; set; }


        [Required(ErrorMessage = "O campo Dia de cobrança é Obrigatório")]
        public int BillingDay { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}