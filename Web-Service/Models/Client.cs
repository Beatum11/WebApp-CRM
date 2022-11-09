using System.ComponentModel.DataAnnotations;

namespace Web_Service.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }


        public Client(string name, string email, string message)
        {
            Name = name;
            Email = email;
            Message = message;
        }

        public Client()
        {

        }
    }
}
