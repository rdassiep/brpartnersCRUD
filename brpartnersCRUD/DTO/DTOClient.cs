using brpartnersCRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace brpartnersCRUD.DTO
{
    public class DTOClient
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do cliente!")]
        [DisplayName("Nome do cliente")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Insira o email do cliente!")]
        [DisplayName("Email do cliente")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira um CPF ou CNPJ do cliente!")]
        [DisplayName("CPF/CNPJ do cliente")]
        public string Document { get; set; }

        public DTOAddress FiscalAddress { get; set; }

        public DTOAddress BillingAddress { get; set; }

        public DTOAddress ShippingAddress { get; set; }

    }
}
