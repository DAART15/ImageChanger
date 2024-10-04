namespace ImageChanger.Models
{
    public class PictureInformation
    {
        public byte[]? FileData { get; set; }
        public double? FileSize { get; set; }
        public string? Url { get; set; }
        public string? Format { get; set; }
        public string? FileName { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
