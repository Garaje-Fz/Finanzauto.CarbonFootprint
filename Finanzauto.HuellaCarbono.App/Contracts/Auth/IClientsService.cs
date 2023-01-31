namespace Finanzauto.HuellaCarbono.App.Contracts.Auth
{
    public interface IClientsService
    {
        Task<bool> ValidateApiKey(string apiKey, string domain, string ip);
        Task<Dictionary<string, Guid>> GetActiveClients();
        Task InvalidateApiKey(string apiKey);
    }
}
