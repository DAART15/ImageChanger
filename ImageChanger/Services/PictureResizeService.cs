using ImageChanger.Interfaces;
using ImageChanger.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace ImageChanger.Services
{
    public class PictureResizeService : IPictureResizeService
    {
        private ImageFormat GetFormat(string format)
        {
            return format switch
            {
                "Jpeg" => ImageFormat.Jpeg,
                "Png" => ImageFormat.Png,
                "Gif" => ImageFormat.Gif,
                _ => ImageFormat.Jpeg
            };
        }
        private static Size GetSize(Bitmap original, int maxWH)
        {
            int maxPixels = maxWH;
            int originalWidth = original.Width;
            int originalHeight = original.Height;
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
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public async Task<byte[]> ChangeSizeBySpecificWHAsync(PictureFile file, int width, int height, string format, bool changeFormat)
        {
            using var stream = new MemoryStream();
            await file.File.OpenReadStream(long.MaxValue).CopyToAsync(stream);
            stream.Position = 0;
            using Bitmap bitmap = new Bitmap(stream);
            if (!changeFormat)
            {
                format = bitmap.RawFormat.ToString();
            }
            using var streamForBytes = new MemoryStream();
            using var resizedBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bitmap, 0, 0, width, height);
            }
            var imageFormat = GetFormat(format);
            var encoder = GetEncoder(imageFormat);
            if (format == "Jpeg" && encoder != null)
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                resizedBitmap.Save(streamForBytes, encoder, encoderParams);
            }
            else
            {
                resizedBitmap.Save(streamForBytes, imageFormat);
            }
            streamForBytes.Position = 0;
            return streamForBytes.ToArray();
        }
        public async Task<byte[]> ChangeSizeByMaxWHAsync(PictureFile file, int maxWH, string format, bool changeFormat)
        {
            using var stream = new MemoryStream();
            await file.File.OpenReadStream(long.MaxValue).CopyToAsync(stream);
            stream.Position = 0;
            using Bitmap bitmap = new Bitmap(stream);
            if (!changeFormat)
            {
                format = bitmap.RawFormat.ToString();
            }
            using var streamForBytes = new MemoryStream();
            Size newSize = GetSize(bitmap, maxWH);
            using var resizedBitmap = new Bitmap(newSize.Width, newSize.Height);
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(bitmap, 0, 0, newSize.Width, newSize.Height);
            }
            var imageFormat = GetFormat(format);
            var encoder = GetEncoder(imageFormat);
            if (format == "Jpeg" && encoder != null)
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                resizedBitmap.Save(streamForBytes, encoder, encoderParams);
            }
            else
            {
                resizedBitmap.Save(streamForBytes, imageFormat);
            }
            streamForBytes.Position = 0;
            return streamForBytes.ToArray();
        }
        public async Task<byte[]> ChangeJustFormatAsync(PictureFile file, string format)
        {
            using var stream = new MemoryStream();
            await file.File.OpenReadStream(long.MaxValue).CopyToAsync(stream);
            stream.Position = 0;
            using Bitmap bitmap = new Bitmap(stream);
            using var streamForBytes = new MemoryStream();
            var imageFormat = GetFormat(format);
            if (format == "Jpeg")
            {
                var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                bitmap.Save(streamForBytes, jpegEncoder, encoderParams);
            }
            else
            {
                bitmap.Save(streamForBytes, imageFormat);
            }
            streamForBytes.Position = 0;
            return streamForBytes.ToArray();
        }
    }
}
