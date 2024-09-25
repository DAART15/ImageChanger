namespace ImageChanger.Models
{
    public class PictureInformation
    {
        public byte[]? FileData { get; set; }
        public string? FileName { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
