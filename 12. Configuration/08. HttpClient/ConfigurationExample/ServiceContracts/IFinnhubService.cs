using System;
namespace ConfigurationExample.ServiceContracts
{
    public interface IFinnhubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}

