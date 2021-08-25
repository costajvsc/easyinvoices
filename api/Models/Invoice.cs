using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("invoices")]
    public partial class Invoice 
    {
        [Key]
        public int IdInvoice { get; set; }

        [Required(ErrorMessage = "O campo Data de Contratação é obrigatório.")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "O campo Método de cobrança é Obrigatório")]
        public string BillingMethod { get; set; }


        [Required(ErrorMessage = "O campo Dia de cobrança é Obrigatório")]
        public int BillingDay { get; set; }

        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }

        public int IdPlan { get; set; }
        public Plan Plan { get; set; }
    
    }
}