using System.ComponentModel.DataAnnotations;

namespace brpartnersCRUD.Models
{
    public class Address
    {
        

     
        public Address()
        {
            
        }

        public Address(string street, int number, string zipCode, AddressType type)
        {

            Street = street;
            Number = number;
            ZipCode = zipCode;
            Type = type;
        }

        public int ClientId { get; set; }
        
        public Client Client { get; set; }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Street { get;  set; }
        [Required]
        public int Number { get;set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public AddressType Type { get; set; }


    }
    public enum AddressType { Fiscal = 0, Billing = 1, Shipping = 2 }
}
