using BitcoinBlockSolution.Core.Services;
using BitcoinBlockSolution.Core.Services.Impl;
using BitcoinBlockSolution.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinBlockSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitcoinBlockController : ControllerBase
    {
        private readonly IBlockchainService _blockchainService;
        private readonly int HttpFailStatusCode; // допустим enum

        public BitcoinBlockController(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;

            HttpFailStatusCode = 500; // код ошибки сервера
        }

        [HttpGet("{blockHash}")]
        public async Task<IActionResult> GetBlock(string blockHash)
        {
            try
            {
                var block = await _blockchainService.GetBlockAsync(blockHash);
                CsvHelper.SaveBlockToCsv(block);
                return Ok(block);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpFailStatusCode, ex.Message);
            }
        }
    }
}
