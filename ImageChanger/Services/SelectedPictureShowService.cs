using ImageChanger.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace ImageChanger.Services
{
    public class SelectedPictureShowService : ISelectedPictureShowService
    {
        public async Task<string> ReturnSelectedPictureAsUrl(IBrowserFile selectedImage)
        {
            using var memoryStream = new MemoryStream();
            await selectedImage.OpenReadStream(long.MaxValue).CopyToAsync(memoryStream);
            return $"data:{selectedImage.ContentType};base64,{Convert.ToBase64String(memoryStream.ToArray())}";
        }
    }
}
