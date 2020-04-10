using Business.Dto;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ILottoServiceProvider
    {
        Task<DrawApiResponse> GetOpenDraws(DrawRequest request);
    }
}
