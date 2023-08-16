using WebApplicationFootBall.Business.Dtos.CreateDto;

namespace WebApplicationFootBall.Business.Dtos.CreateDtos
{
    public class CountryPostRequestDto : CreateDtoEntities
    {
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string FlagUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
