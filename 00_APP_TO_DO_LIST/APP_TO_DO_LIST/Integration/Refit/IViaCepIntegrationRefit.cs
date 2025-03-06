using APP_TO_DO_LIST.Integration.Response;
using Refit;

namespace APP_TO_DO_LIST.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{zipCode}/json")] //assinatura 
        Task<ApiResponse<ViaCepResponse>> GetByViaCep(string zipCode); // a resposta será todos os objetos da class ViaCepResponse
    }
}
