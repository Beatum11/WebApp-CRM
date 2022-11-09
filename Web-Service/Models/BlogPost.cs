using System.ComponentModel.DataAnnotations;

namespace Web_Service.Models
{
    public class BlogPost
    {
        #region Fields

        [Key]
        public int Id { get; set; }
        public string? HeadLine { get; set; }

        public string? Synopsis { get; set; }

        public string? Text { get; set; }

        public string? Image { get; set; }

        #endregion


        #region Constructors
        public BlogPost(string? headLine, string? synopsis, string? text, string? image)
        {
            HeadLine = headLine;
            Synopsis = synopsis;
            Text = text;
            Image = image;
        }

        public BlogPost()
        {

        }

        #endregion

    }
}
