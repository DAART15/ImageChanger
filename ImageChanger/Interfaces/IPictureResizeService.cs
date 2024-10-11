using ImageChanger.Models;

namespace ImageChanger.Interfaces
{
    public interface IPictureResizeService
    {
        Task<byte[]> ChangeJustFormatAsync(PictureFile file, string format);
        Task<byte[]> ChangeSizeByMaxWHAsync(PictureFile file, int maxWH, string format, bool changeFormat);
        Task<byte[]> ChangeSizeBySpecificWHAsync(PictureFile file, int width, int height, string format, bool changeFormat);
    }
}
