using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Insira o nome do cliente!")]
        [DisplayName("Nome do cliente")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Insira o email do cliente!")]
        [DisplayName("Email do cliente")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira um CPF ou CNPJ do cliente!")]
        [DisplayName("CPF/CNPJ do cliente")]
        public string Document { get; set; }

        
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

    }
}
