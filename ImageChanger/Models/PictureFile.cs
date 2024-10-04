using Microsoft.AspNetCore.Components.Forms;

namespace ImageChanger.Models
{
    public class PictureFile
    {
        //public IFormFile Image { get; set; }
        public IBrowserFile? File { get; set; }

    }
}
