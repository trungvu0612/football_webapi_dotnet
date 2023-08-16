namespace WebApplicationFootBall.Business.Dtos.ReadDtos
{
    public class CountryGetResponseDto : BaseDtoEntities
    {
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string FlagUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class StadiumPlayerDetailDto : CountryGetResponseDto
    {
        public IList<StadiumGetResponseDto> Stadiums { get; set; }
        public IList<PlayerGetResponseDto> Players { get; set; }
    }
}
