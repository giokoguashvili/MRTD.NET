namespace HelloWord
{
    public interface IBerTLV
    {
        string T { get; }
        string L { get; }
        string V { get; }
        string TL { get; }
        IBerTLV[] Data { get; }
    }
}
