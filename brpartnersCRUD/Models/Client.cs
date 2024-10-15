using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace brpartnersCRUD.Models
{
    public class Client
    {
        //name
        //Email
        //Address (3 variations)
        //Document (National Registration Validator)
        
 
        public Client()
        {
            
        }
        public Client(string name, string email, string document) {
            
            Name = name;
            Email = email;
            Document = document;
            //Addresses = addresses;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "")]
        [DisplayName("CPF/CNPJ")]
        public string Document { get; set; }
       // [Required]
        //public IList<Address> Addresses { get; private set; }


    }
}
