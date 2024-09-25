namespace ImageChanger.Services
{
    public static class PictureToByteService
    {
        public static async Task<byte[]> ConvertToByte(IFormFile file)
        {
            using var memorystream = new MemoryStream();
            await file.CopyToAsync(memorystream);
            return memorystream.ToArray();
        }
    }
}
