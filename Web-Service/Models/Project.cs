using System.ComponentModel.DataAnnotations;

namespace Web_Service.Models
{
    public class Project
    {

        [Key]
        public int Id { get; set; }

        public string? HeadLine { get; set; }

        public string? Text { get; set; }

        public string? Image { get; set; }


        #region Constructors
        public Project(string? headLine, string? text, string? image)
        {
            HeadLine = headLine;
            Text = text;
            Image = image;
        }

        public Project()
        {

        }

        #endregion
    }
}
