﻿namespace Finanzauto.HuellaCarbono.App.Contracts.Auth
{
    public interface ICacheService
    {
        ValueTask<string?> GetOwnerIdFromApiKey(string apiKey, string domain, string ip);
        Task InvalidateApiKey(string apiKey);
    }
}
