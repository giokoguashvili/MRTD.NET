namespace HelloWord
{
    public interface IBerTLV
    {
        string T { get; }
        string L { get; }
        string V { get; }
        IBerTLV[] Data { get; }
    }
}
