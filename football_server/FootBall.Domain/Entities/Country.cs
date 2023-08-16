using FootBallWeb.Domain.Common;

namespace FootBallWeb.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Stadiums = new List<Stadium>();
            Players = new List<Player>();
        }
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string FlagUrl { get; set; }
        public int DisplayOrder { get; set; }
        public IList<Stadium> Stadiums { get; set; }
        public IList<Player> Players { get; set; }
    }
}
