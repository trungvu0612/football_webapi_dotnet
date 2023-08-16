using FootBallWeb.Domain.Common;

namespace FootBallWeb.Domain.Entities
{
    public class Club : BaseEntity
    {
        public Club()
        {
            Players = new List<Player>();
        }
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string FaceBookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string InstagramUrl { get; set; }
        public int? StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public IList<Player> Players { get; set; }
    }
}
