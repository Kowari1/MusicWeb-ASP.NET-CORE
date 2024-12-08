namespace MusicWebsite.Server.DTO
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioFileUrl { get; set; }
        public string CoverFileUrl { get; set; }
    }
}
