using BitcoinBlockSolution.Domain.Models;

namespace BitcoinBlockSolution.Core.Services.Impl
{
    public interface IBlockchainService
    {
        Task<BlockModel> GetBlockAsync(string blockHash);
    }
}
