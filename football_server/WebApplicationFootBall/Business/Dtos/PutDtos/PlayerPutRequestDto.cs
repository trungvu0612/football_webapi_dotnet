using WebApplicationFootBall.Business.Dtos.UpdateDto;

namespace WebApplicationFootBall.Business.Dtos.UpdateDtos
{
    public class PlayerPutRequestDto : UpdateDtoEntities
    {
        public string Name { get; set; }
        public int? ShirtNo { get; set; }
        public int? ClubId { get; set; }
        public int? PlayerPositionId { get; set; }
        public string PhotoUrl { get; set; }
        public int? CountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? HeightlnCm { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
