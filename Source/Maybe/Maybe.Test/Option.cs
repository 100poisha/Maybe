using NUnit.Framework;
using System;

namespace Maybe.Test
{

    [TestFixture]
    public class OptionTest
    {
        //Option<T>
        [Test]
        public void Default_struct()
        {
            var o = default(Option<int>);
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { var i = o.Value; });
        }

        [Test]
        public void Default_class()
        {
            var o = default(Option<string>);
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { var s = o.Value; });
        }

        [Test]
        public void Default_nullable()
        {
            var o = default(Option<int?>);
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { int? ni = o.Value; });
        }

        [Test]
        public void ToString_Some()
        {
            var s = "foo";
            var o = Option.Some(s);

            o.ToString().Is(string.Format("Some({0})", s.ToString()));
        }

        [Test]
        public void ToString_None()
        {
            var o = Option.None<string>();

            o.ToString().Is("None");
        }

        private object[] Equals_TestCaseSource =
        {
            new object[]{ Option.Some("foo"), Option.Some("foo"), true },
            new object[]{ Option.Some("foo"), Option.Some("bar"), false },
            new object[]{ Option.Some("foo"), Option.None<string>(), false },
            new object[]{ Option.None<string>(), Option.None<string>(), true },
        };
        [TestCaseSource("Equals_TestCaseSource")]
        public void Equals(Option<string> left, Option<string> right, bool equals)
        {
            left.Equals(right).Is(equals);
            (left == right).Is(equals);
            (left != right).Is(!equals);
        }

        //Option
        [Test]
        public void Some_Struct()
        {
            var o = Option.Some(1);
            o.IsInstanceOf<Option<int>>();
            o.HasValue.IsTrue();
            o.Value.Is(1);
        }

        [Test]
        public void Some_Class()
        {
            var o = Option.Some("foo");
            o.IsInstanceOf<Option<string>>();
            o.HasValue.IsTrue();
            o.Value.Is("foo");
        }

        [Test]
        public void Some_Nullable()
        {
            var o = Option.Some((int?)42);
            o.IsInstanceOf<Option<int?>>();
            o.HasValue.IsTrue();
            o.Value.Is((int?)42);
        }

        [Test]
        public void None_Struct()
        {
            var o = Option.None<int>();
            o.IsInstanceOf<Option<int>>();
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { int i = o.Value; });
        }

        [Test]
        public void None_Class()
        {
            var o = Option.None<string>();
            o.IsInstanceOf<Option<string>>();
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { string s = o.Value; });
        }

        [Test]
        public void None_Nullable()
        {
            var o = Option.None<int?>();
            o.IsInstanceOf<Option<int?>>();
            o.HasValue.IsFalse();
            Assert.Catch<InvalidOperationException>(() => { int? ni = o.Value; });
        }

        private object[] Bind_TestCaseSource =
        {
            new object[]{ Option.Some("foo"), Option.Some(3), true },
            new object[]{ Option.Some(""), Option.None<int>(), true },
            new object[]{ Option.None<string>(), Option.None<int>(), false },
        };
        [TestCaseSource("Bind_TestCaseSource")]
        public void Bind(Option<string> input, Option<int> expected, bool isRunning)
        {
            // F# Code:
            // let func = function
            //     | s when not (String.IsNullOrWhiteSpace s) -> Some s.Length
            //     | _ -> None;;
            //
            // input >>= func;;
            bool funcRunning = false;
            Func<string, Option<int>> func = s =>
            {
                funcRunning = true;
                if (string.IsNullOrWhiteSpace(s)) return Option.None<int>();
                else return Option.Some(s.Length);
            };

            input.Bind(func).Is(expected);
            funcRunning.Is(isRunning);
        }

        private object[] BindChain_TestCaseSource = 
        {
            new object[]{ Option.Some("fooo"), Option.Some(2), true, true },
            new object[]{ Option.Some("foo"), Option.None<int>(), true, true },
            new object[]{ Option.Some(""), Option.None<int>(), true, false },
            new object[]{ Option.None<string>(), Option.None<int>(), false, false },
        };
        [TestCaseSource("BindChain_TestCaseSource")]
        public void BindChain(Option<string> value, Option<int> expected, bool isFirstCalled, bool isSecondCalled)
        {
            bool callFirstMethod = false;
            bool callSecondMethod = false;

            // F# Code:
            // input >>= (fun s -> 
            //     match (String.IsNullOrWhiteSpace s) with
            //     | false -> Some s.Length
            //     | true -> None)
            // >>= (fun i ->
            //     match (i % 2 = 0) with
            //     | true -> Some (i / 2)
            //     | false -> None);;
            Func<string, Option<int>> firstMethod = s =>
            {
                callFirstMethod = true;
                if (string.IsNullOrEmpty(s)) return Option.None<int>();
                else return Option.Some(s.Length);
            };

            Func<int, Option<int>> secondMethod = i =>
            {
                callSecondMethod = true;
                if (i % 2 != 0) return Option.None<int>();
                else return Option.Some(i / 2);
            };

            value.Bind(firstMethod)
                .Bind(secondMethod)
                .Is(expected);

            callFirstMethod.Is(isFirstCalled);
            callSecondMethod.Is(isSecondCalled);
        }

        private object[] BindNest_TestCaseSource = 
        {
            new object[]{ Option.Some(1), Option.Some(2), Option.Some(3), true, true },
            new object[]{ Option.Some(1), Option.None<int>(), Option.None<int>(), true, false },
            new object[]{ Option.None<int>(),  Option.Some(2), Option.None<int>(), false, false },
            new object[]{ Option.None<int>(), Option.None<int>(), Option.None<int>(), false, false },
        };
        [TestCaseSource("BindNest_TestCaseSource")]
        public void BindNest(Option<int> value1, Option<int> value2, Option<int> expected, bool isOuterCalled, bool isInnerCalled)
        {
            bool callOuterMethod = false;
            bool callInnerMethod = false;

            // F# Code:
            // value1 >>= (fun outer ->
            //     value2 >>= (fun inner ->
            //         Some (outer + inner)));;
            value1.Bind(outer =>
                {
                    callOuterMethod = true;

                    return value2.Bind(inner =>
                        {
                            callInnerMethod = true;

                            return Option.Some(outer + inner);
                        });
                })
                .Is(expected);

            callOuterMethod.Is(isOuterCalled);
            callInnerMethod.Is(isInnerCalled);
        }

        private object[] BindQuery_TestCaseSource =
        {
            new object[] { Option.Some("foo"), Option.Some(3), Option.Some(6) },
            new object[] { Option.Some("foo"), Option.None<int>(), Option.None<int>() },
            new object[] { Option.None<string>(), Option.Some(3), Option.None<int>() },
            new object[] { Option.None<string>(), Option.None<int>(), Option.None<int>() },
        };
        [TestCaseSource("BindQuery_TestCaseSource")]
        public void BindQuery(Option<string> value1, Option<int> value2, Option<int> expected)
        {
            // F# Code: 
            // maybe {
            //     let! s = value1
            //     let! i = value2
            //     return s.Length + i
            // };;
            var result = from s in value1
                         from i in value2
                         select (s.Length) + i;

            result.Is(expected);
        }

        // (return x) >>= f == f x
        [Test]
        public void MonadLaw1()
        {
            // F# Code:
            // let func = function
            //     | i when i % 2 = 0 -> Some (i / 2)
            //     | _ -> None;;
            //
            // (Some 1 >>= func) = (func 1);;
            // (Some 2 >>= func) = (func 2);;
            Func<int, Option<int>> func = i =>
            {
                if (i % 2 == 0) return Option.Some(i / 2);
                else return Option.None<int>();
            };

            Option.Some(1).Bind(func).Is(func(1));
            Option.Some(2).Bind(func).Is(func(2));
        }

        // m >>= return == m
        [Test]
        public void MonadLaw2()
        {
            // F# Code:
            // ((Some 1) >>= returnM) = (Some 1);;
            Func<int, Option<int>> _return = i => Option.Some(i);
            Option.Some(1).Bind(_return).Is(Option.Some(1));
        }

        // (m >>= f) >>= g == m >>= (\x -> f x >>= g)
        [Test]
        public void MonadLaw3()
        {
            // F# Code:
            // let func1 = function
            //     | i when i % 2 = 0 -> Some (i / 2)
            //     | _ -> None;;
            //
            // let func2 = function
            //     | i when i % 3 = 0 -> Some (i / 3)
            //     | _ -> None;;
            //
            // (((Some 6) >>= func1) >>= func2) = ((Some 6) >>= (fun x -> ((func1 x) >>= func2)));;
            // (((Some 4) >>= func1) >>= func2) = ((Some 4) >>= (fun x -> ((func1 x) >>= func2)));;
            // (((Some 3) >>= func1) >>= func2) = ((Some 3) >>= (fun x -> ((func1 x) >>= func2)));;
            Func<int, Option<int>> func1 = i =>
            {
                if (i % 2 == 0) return Option.Some(i / 2);
                else return Option.None<int>();
            };

            Func<int, Option<int>> func2 = i =>
            {
                if (i % 3 == 0) return Option.Some(i / 3);
                else return Option.None<int>();
            };

            (Option.Some(6).Bind(func1)).Bind(func2).Is(Option.Some(6).Bind(i => func1(i).Bind(func2)));
            (Option.Some(4).Bind(func1)).Bind(func2).Is(Option.Some(4).Bind(i => func1(i).Bind(func2)));
            (Option.Some(3).Bind(func1)).Bind(func2).Is(Option.Some(3).Bind(i => func1(i).Bind(func2)));
        }
    }
}
