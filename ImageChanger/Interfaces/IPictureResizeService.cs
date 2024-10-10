using ImageChanger.Models;

namespace ImageChanger.Interfaces
{
    public interface IPictureResizeService
    {
        Task<byte[]> ChangeJustFormat(PictureFile file, string format);
        Task<byte[]> ChangeSizeByMaxWH(PictureFile file, int maxWH, string format, bool changeFormat);
        Task<byte[]> ChangeSizeBySpecificWH(PictureFile file, int width, int height, string format, bool changeFormat);
    }
}
