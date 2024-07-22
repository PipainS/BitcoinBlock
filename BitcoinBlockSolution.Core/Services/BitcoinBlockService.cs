using BitcoinBlockSolution.Core.Services.Impl;
using BitcoinBlockSolution.Core.Settings;
using BitcoinBlockSolution.Domain.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BitcoinBlockSolution.Core.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly HttpClient _httpClient;
        private readonly BlockchainApiSettings _settings;

        public BlockchainService(HttpClient httpClient, IOptions<BlockchainApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        public async Task<BlockModel> GetBlockAsync(string blockHash)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_settings.BaseUrl}{blockHash}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    if (jsonResponse.Contains("html") || jsonResponse.Contains("Forbidden"))
                    {
                        throw new Exception("Error while getting response");
                    }

                    return JsonConvert.DeserializeObject<BlockModel>(jsonResponse);
                }
                else throw new HttpRequestException($"Error fetching block data: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new ApplicationException("Error fetching block data", ex);
            }
        }
    }
}
