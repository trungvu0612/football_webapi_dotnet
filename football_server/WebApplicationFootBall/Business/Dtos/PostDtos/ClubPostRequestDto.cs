using WebApplicationFootBall.Business.Dtos.CreateDto;

namespace WebApplicationFootBall.Business.Dtos.CreateDtos
{
    public class ClubPostRequestDto : CreateDtoEntities
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
}
