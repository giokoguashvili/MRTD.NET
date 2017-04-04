namespace SmartCardApi.Infrastructure
{
    public class Number : INumber
    {
        private readonly int _num;

        public Number(int num)
        {
            _num = num;
        }

        public int Value()
        {
            return _num;
        }
    }
}
