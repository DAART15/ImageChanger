using ImageChanger.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ImageChanger.Interfaces
{
    public interface ISelectedPictureShowService
    {
        Task<PictureInformation> ReturnSelectedPictureAsUrl(PictureFile file);
        Task<PictureInformation> ReturnSelectedPictureAsUrl(byte[] bytes);
    }
}
