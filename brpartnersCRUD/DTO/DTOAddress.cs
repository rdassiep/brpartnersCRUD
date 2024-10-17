using brpartnersCRUD.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace brpartnersCRUD.DTO
{
    public class DTOAddress
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um logradouro!")]
        [DisplayName("Logradouro")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Insira o número do endereço!")]
        [DisplayName("Número")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Insira o código postal!")]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }
        [Required]
        public AddressType Type { get; set; }


    }
    public enum AddressType { Fiscal = 0, Billing = 1, Shipping = 2 }
}
