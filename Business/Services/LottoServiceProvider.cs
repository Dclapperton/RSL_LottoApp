using System.Net.Http;
using System.Threading.Tasks;
using Business.Dto;
using Newtonsoft.Json;

namespace Business.Services
{
    public class LottoServiceProvider : ILottoServiceProvider
    {
        private readonly HttpClient _httpClient;

        public LottoServiceProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DrawApiResponse> GetOpenDraws(DrawRequest request)
        {
            try
            {
                var myContent = JsonConvert.SerializeObject(request);

                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _httpClient.PostAsync("/sales/vmax/web/data/lotto/opendraws", byteContent).ConfigureAwait(false);

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DrawApiResponse>(json);
            }
            catch (System.Exception)
            {
               //todo: log error here
                throw;
            }
        }
    }
}
