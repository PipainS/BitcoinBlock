namespace BitcoinBlockSolution.Domain.Models
{
    public class BlockModel
    {
        public string Hash { get; set; }
        public int Ver { get; set; }
        public string PrevBlock { get; set; }
        public string MrklRoot { get; set; }
        public int Time { get; set; }
        public int Bits { get; set; }
        public long Nonce { get; set; }
        public int NTx { get; set; }
        public int Size { get; set; }
        public int BlockIndex { get; set; }
        public bool MainChain { get; set; }
        public int Height { get; set; }
        public int ReceivedTime { get; set; }
        public string RelayedBy { get; set; }
        public List<TransactionModel> Tx { get; set; }
    }
    public class TransactionModel
    {
        public string hash { get; set; }
        public int ver { get; set; }
        public int vin_sz { get; set; }
        public int vout_sz { get; set; }
        public string lock_time { get; set; }
        public int size { get; set; }
        public string relayed_by { get; set; }
        public int block_height { get; set; }
        public string tx_index { get; set; }
        public List<Input> inputs { get; set; }
        public List<Out> @out { get; set; }
    }

    public class Input
    {
        public PrevOut prev_out { get; set; }
        public string script { get; set; }
    }

    public class Out
    {
        public string value { get; set; }
        public string hash { get; set; }
        public string script { get; set; }
    }

    public class PrevOut
    {
        public string hash { get; set; }
        public string value { get; set; }
        public string tx_index { get; set; }
        public string n { get; set; }
    }
}
