using System.ComponentModel.DataAnnotations;

namespace Web_Service.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }


        #region Constructors
        public Service(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public Service()
        {

        }

        #endregion

    }
}
