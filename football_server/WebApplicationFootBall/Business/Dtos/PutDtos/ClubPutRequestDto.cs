using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebApplicationFootBall.Business.Dtos.UpdateDtos
{
    public class ClubPutRequestDto : UpdateDtoEntities
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
