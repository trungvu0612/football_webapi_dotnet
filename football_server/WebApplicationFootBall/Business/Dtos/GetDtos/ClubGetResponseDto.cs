namespace WebApplicationFootBall.Business.Dtos.ReadDtos
{
    public class ClubGetResponseDto : BaseDtoEntities
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string FaceBookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string InstagramUrl { get; set; }
        public int? StadiumId { get; set; }
    }
    public class StadiumPlayerDetailClubDto : ClubGetResponseDto
    {
        public StadiumGetResponseDto Stadium { get; set; }
        public IList<PlayerGetResponseDto> Players { get; set; }
    }
}
