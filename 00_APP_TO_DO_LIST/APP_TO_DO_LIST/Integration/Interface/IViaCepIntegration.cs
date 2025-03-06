using APP_TO_DO_LIST.Integration.Response;

namespace APP_TO_DO_LIST.Integration.Interface
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetByViaCep(string zipCode);
    }
}
