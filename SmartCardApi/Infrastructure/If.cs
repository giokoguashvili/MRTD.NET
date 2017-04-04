using System;

namespace SmartCardApi.Infrastructure
{
    public class If<T1, T2>
    {
        private readonly T1 _a;
        private readonly T2 _b;
        private readonly Func<T1, T2, bool> _predicate;

        public If(
                T1 a,
                T2 b,
                Func<T1, T2, bool> predicate 
            )
        {
            _a = a;
            _b = b;
            _predicate = predicate;
        }

        public TResult Result<TResult>(
                Func<T1, T2, TResult> thenFunct,
                Func<T1, T2, TResult> elseFunc
            )
        {
            if (_predicate(_a, _b))
            {
                return thenFunct(_a, _b);
            }
            else
            {
                return elseFunc(_a, _b);
            }
        }

        //public TResult Result<TResult>(
        //        Func<T1, T2, TResult> thenFunct,
        //        Action<T1, T2> elseFunc
        //    )
        //{
        //    if (_predicate(_a, _b))
        //    {
        //        return thenFunct(_a, _b);
        //    }
        //    else
        //    {
        //        elseFunc(_a, _b);
        //        return new TResult();
        //    }
        //}
    }

    //return new If<IBinary, IBinary>(
    //            cc,
    //            responseApduDO8E,
    //            (a, b) => a.Bytes().SequenceEqual(b.Bytes())
    //        ).Result(
    //            (a, b) =>
    //            {
    //                Console.WriteLine(
    //                    "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
    //                    new Hex(cc),
    //                    new Hex(responseApduDO8E)
    //                );
    //                return b.Bytes();
    //            },
    //            (a, b) =>
    //            {
    //                throw new Exception(
    //                    String.Format(
    //                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
    //                        new Hex(cc),
    //                        new Hex(responseApduDO8E)
    //                    )
    //                );
    //            }
    //        );

}
