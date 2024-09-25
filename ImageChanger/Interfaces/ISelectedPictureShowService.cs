using Microsoft.AspNetCore.Components.Forms;

namespace ImageChanger.Interfaces
{
    public interface ISelectedPictureShowService
    {
        Task<string> ReturnSelectedPictureAsUrl(IBrowserFile selectedImage);
    }
}
