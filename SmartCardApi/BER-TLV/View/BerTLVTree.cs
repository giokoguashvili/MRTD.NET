namespace SmartCardApi.View
{
    public class BerTLVTree 
    {
        private readonly IBerTLV[] _berTlvList;

        public BerTLVTree(IBerTLV berTLV)
        {
            _berTlvList = new IBerTLV[] { berTLV };
        }

        public BerTLVEnumberable DFS()
        {
            return new BerTLVEnumberable(_berTlvList);
        }
    }
}
