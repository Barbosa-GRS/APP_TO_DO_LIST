using APP_TO_DO_LIST.Integration.Interface;
using APP_TO_DO_LIST.Integration.Refit;
using APP_TO_DO_LIST.Integration.Response;

namespace APP_TO_DO_LIST.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<ViaCepResponse> GetByViaCep(string zipCode)
        {
            var response = await _viaCepIntegrationRefit.GetByViaCep(zipCode);
            if (response != null && response.IsSuccessStatusCode)
            {
                return response.Content;
            }
            return null;
        }
    }
}
