using ImageChanger.Interfaces;
using ImageChanger.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageChanger.Services
{
    public class PictureResizeService : IPictureResizeService
    {
        public async Task<PictureInformation> ResizePicture(PictureFile file,int maxWH, int width, int height, string format)
        {
            
            using var stream = new MemoryStream();
            await file.File.OpenReadStream(long.MaxValue).CopyToAsync(stream);
            using Bitmap bitmap = new Bitmap(stream);
            Image thumbnail;
            using var streamForBytes = new MemoryStream();
            if (format != "Jpeg" && maxWH == 0 && width == 0 && height == 0)
            {
                /*thumbnail = bitmap.GetThumbnailImage(bitmap.Width, bitmap.Height, null, IntPtr.Zero);
                thumbnail.Save(streamForBytes, GetFormat(format));*/
                thumbnail = ChangeImageFornat(bitmap, format);
                
            }
            else if (maxWH > 0)
            {
                Size thumbnailSize = GetThumbnailSize(bitmap, maxWH);
                thumbnail = bitmap.GetThumbnailImage(thumbnailSize.Width, thumbnailSize.Height, null, IntPtr.Zero);
                var formatForChange = GetFormat(format);
                thumbnail.Save(streamForBytes, formatForChange);
            }
            else
            {
                thumbnail = bitmap.GetThumbnailImage(width, height, null, IntPtr.Zero);
                thumbnail.Save(streamForBytes, GetFormat(format));
            }
            byte[] fileBytes = streamForBytes.ToArray();
            var pictureInformation = new PictureInformation
            {
                Width = thumbnail.Width,
                Height = thumbnail.Height,
                Format = thumbnail.RawFormat.ToString(),
                FileName = file.File.Name,
                FileSize = fileBytes.Length,
                Url = $"data:{file.File.ContentType};base64,{Convert.ToBase64String(fileBytes)}"
            };
            return pictureInformation;
        }
        private Image ChangeImageFornat(Bitmap bitmap, string format)
        {
            using var stream = new MemoryStream();
            //var formatForChange = GetFormat(format);
            bitmap.Save(stream, ImageFormat.Icon);
            stream.Position = 0;
            return Image.FromStream(stream);
        }
        private ImageFormat GetFormat(string format)
        {
            switch (format)
            {
                case "Jpeg":
                    return ImageFormat.Jpeg;
                case "Icon":
                    return ImageFormat.Icon;
                case "Png":
                    return ImageFormat.Png;
                case "Gif":
                    return ImageFormat.Gif;
                case "Tiff":
                    return ImageFormat.Tiff;
                case "Exif":
                    return ImageFormat.Exif;
                case "Emf":
                    return ImageFormat.Emf;
                case "Bmp":
                    return ImageFormat.Bmp;
                case "Wmf":
                    return ImageFormat.Wmf;
                case "MemoryBmp":
                    return ImageFormat.MemoryBmp;
                default:
                    return ImageFormat.Jpeg;
            }
        }
        private static Size GetThumbnailSize(Bitmap original, int maxWH)
        {
            int maxPixels = maxWH;

            int originalWidth = original.Width;
            int originalHeight = original.Height;

            if (originalWidth <= maxPixels && originalHeight <= maxPixels)
            {
                return new Size(originalWidth, originalHeight);
            }

            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }
    }
}
