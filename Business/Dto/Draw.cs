using System;

namespace Business.Dto
{
    public class Draw
    {
        public string ProductId { get; set; }

        public int DrawNumber { get; set; }

        public string DrawDisplayName { get; set; }

        public DateTime DrawDate { get; set; }

        public string DrawLogoUrl { get; set; }

        public string DrawType { get; set; }

        public decimal Div1Amount { get; set; }

        public bool IsDiv1Estimated { get; set; }

        public bool IsDiv1Unknown { get; set; }

        public string DrawCloseDateTimeUTC { get; set; }

        public string DrawEndSellDateTimeUTC { get; set; }

        public long DrawCountDownTimerSeconds { get; set; }
    }
}