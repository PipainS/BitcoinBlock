using BitcoinBlockSolution.Domain.Models;
using System.Text;

namespace BitcoinBlockSolution.Core.Services
{
    public static class CsvHelper
    {
        public static void SaveBlockToCsv(BlockModel block)
        {
            ArgumentNullException.ThrowIfNull(block);

            var folderPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(folderPath, "block_data.csv");

            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

            writer.WriteLine("Hash,Ver,PrevBlock,MrklRoot,Time,Bits,Nonce,NTx,Size,BlockIndex,MainChain,Height,ReceivedTime,RelayedBy");

            writer.WriteLine($"{block.Hash},{block.Ver},{block.PrevBlock},{block.MrklRoot},{block.Time},{block.Bits},{block.Nonce},{block.NTx},{block.Size},{block.BlockIndex},{block.MainChain},{block.Height},{block.ReceivedTime},{block.RelayedBy}");

            writer.WriteLine();
            writer.WriteLine("TransactionHash,TransactionVer,VinSz,VoutSz,LockTime,Size,RelayedBy,BlockHeight,TxIndex,InputPrevOutHash,InputPrevOutValue,InputPrevOutTxIndex,InputPrevOutN,InputScript,OutValue,OutHash,OutScript");

            foreach (var tx in block.Tx)
            {
                foreach (var input in tx.inputs)
                {
                    // Запись данных транзакции
                    writer.WriteLine($"{tx.hash},{tx.ver},{tx.vin_sz},{tx.vout_sz},{tx.lock_time},{tx.size},{tx.relayed_by},{tx.block_height},{tx.tx_index},{input.prev_out.hash},{input.prev_out.value},{input.prev_out.tx_index},{input.prev_out.n},{input.script},{GetOutValues(tx.@out)}");
                }
            }
        }

        private static string GetOutValues(List<Out> outputs)
        {
            var outputList = new List<string>();

            foreach (var output in outputs)
            {
                outputList.Add($"{output.value},{output.hash},{output.script}");
            }

            return string.Join("|", outputList);
        }
    }

}
