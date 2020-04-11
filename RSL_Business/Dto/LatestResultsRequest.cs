using RSL_Business.Dto.Interfaces;

namespace Business.Dto
{
    public class LatestResultsRequest : IDrawRequest
    {
        public string CompanyId { get; set; }

        public int MaxDrawCountPerProduct { get; set; }

        public string[] OptionalProductFilter { get; set; }
    }
}