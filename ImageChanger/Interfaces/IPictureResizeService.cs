using ImageChanger.Models;

namespace ImageChanger.Interfaces
{
    public interface IPictureResizeService
    {
        Task<PictureInformation> ResizePicture(PictureFile file, int maxWH, int width, int height, string format);
    }
}
