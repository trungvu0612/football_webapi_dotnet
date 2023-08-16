namespace WebApplicationFootBall.Business.Dtos.UpdateDto
{
    public class CountryPutRequestDto : UpdateDtoEntities
    {
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string FlagUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
