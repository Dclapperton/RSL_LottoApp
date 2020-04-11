using Business.Dto;
using System.Collections.Generic;

namespace RSL_LottoApp.Models
{
    public class Home
    {
        public List<Draw> OpenDrawItems { get; set; }

        public List<OpenDrawsResult> LatestResultItems { get; set; }
    }
}