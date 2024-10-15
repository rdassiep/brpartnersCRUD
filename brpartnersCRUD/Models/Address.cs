using System.ComponentModel.DataAnnotations;

namespace brpartnersCRUD.Models
{
    public class Address
    {
        // Street
        // Number
        // Complement
        // City
        // State or Province
        // Zip Code
        // Type

        private string _street;
        private int _number;
        private string _complement;
        private string _city;
        private string _state;
        private string _zipCode;
        private AddressType _type;

        public Address()
        {
            
        }

        public Address(string street, int number, string complement, string city, string state, string zipCode, AddressType type)
        {

            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            ZipCode = zipCode;
            Type = type;
        }

        [Key]
        public int Id { get; private set; }
        [Required]
        public string Street { get; private set; }
        [Required]
        public int Number { get; private set; }
        [Required]
        public string Complement { get; private set; }
        [Required]
        public string City { get; private set; }
        [Required]
        public string State { get; private set; }
        [Required]
        public string ZipCode { get; private set; }
        [Required]
        public AddressType Type { get; private set; }


    }
    public enum AddressType { Fiscal = 0, Billing = 1, Delivery = 2 }
}
