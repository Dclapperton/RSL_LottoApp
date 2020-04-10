using System;

namespace Business.Dto
{
    public class DrawRequest
    {
        public string CompanyId { get; set; }

        public int MaxDrawCount { get; set; }

        public string[] OptionalProducgtFilter { get; set; }
    }
}