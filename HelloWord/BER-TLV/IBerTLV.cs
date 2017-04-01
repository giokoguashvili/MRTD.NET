namespace HelloWord
{
    public interface IBerTLV
    {
        string T { get; }
        string L { get; }
        string V { get; }
        string TL { get; }
        string LV { get; }
        IBerTLV[] Data { get; }
    }
}
