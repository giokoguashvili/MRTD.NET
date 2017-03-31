namespace HelloWord
{
    public interface IBerTLV
    {
        string Tag { get; }
        string Len { get; }
        string Val { get; }
        IBerTLV[] Data { get; }
    }
}
