using ImageChanger.Interfaces;
using ImageChanger.Models;
using System.Drawing;

namespace ImageChanger.Services
{
    public class SelectedPictureShowService : ISelectedPictureShowService
    {
        public async Task<PictureInformation> ReturnSelectedPictureAsUrl(PictureFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.File.OpenReadStream(long.MaxValue).CopyToAsync(memoryStream);
            using Bitmap bitmap = new Bitmap(memoryStream);
            var pictureInformation = new PictureInformation
            {
                Width = bitmap.Width,
                Height = bitmap.Height,
                Format = bitmap.RawFormat.ToString(),
                Url = $"data:{file.File.ContentType};base64,{Convert.ToBase64String(memoryStream.ToArray())}"
            };
            return pictureInformation;
        }
    }
}
