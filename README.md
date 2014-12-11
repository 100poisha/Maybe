MaybeFailure
=====

NullReferenceExceptionを駆逐するためのC#向けMaybeモナドライブラリです。

#効果
このライブラリを使用するとこにより、NullReferenceExceptionの発生を抑えることができます。
また、Dictionaryから値を取得するなどの失敗するかもしれない操作を行う際に、プログラムが簡単になる場合があります。

例2:Dictionaryから3つの値を取得して処理を行う場合。
``` C#
var dictionary = new Dictionary<string, int>
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
};

// old code
/*
int i;
if (dictionary.TryGetValue("one", out i))
{
    int i2;
    if (dictionary.TryGetValue("two", out i2))
    {
        int i3;
        if (dictionary.TryGetValue("three", out i3))
        {
            Console.WriteLine(i + i2 + i3);
        }
        else
        {
            Console.WriteLine("error!");
        }
    }
    else
    {
        Console.WriteLine("error!");
    }
}
else
{
    Console.WriteLine("error!");
}
*/

// new code
Option<int> sum = from i in dictionary.MaybeGetValue("one")
          from i2 in dictionary.MaybeGetValue("two")
          from i3 in dictionary.MaybeGetValue("three")
          select i + i2 + i3;

var message = sum.Bind(i => Option.Some(i.ToString()))
    .Or("error!");

Console.WriteLine(message);
```

例2:Dictionaryから3つの値のうちいずれかを取得する場合。
``` C#
var dictionary = new Dictionary<string, int>
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
};

// old code
/*
int i;
if (!dictionary.TryGetValue("one", out i))
{
    if (!dictionary.TryGetValue("two", out i))
    {
        if (!dictionary.TryGetValue("three", out i))
        {
            i = -1;
        }
    }
}

Console.WriteLine(i);
*/

// new code
int i = dictionary.MaybeGetValue("one")
    .Or(dictionary.MaybeGetValue("two"))
    .Or(dictionary.MaybeGetValue("three"))
    .Or(-1);

Console.WriteLine(i);
```

#インストール
NuGetを使用してインストールします。

``` 
PM> Install-Package MaybeFailure
```

#使い方

Option<T>クラスのインスタンスを作成します。
``` C#
Option<int> some1 = Option.Some(42);      //値がある場合。
Option<int> none1 = Option.None<int>();   //値がない場合。

Option<string> some2 = Option.Some("foo");
Option<string> none2 = Option.None<string>();
```

値が存在するかが分からない場合、Maybe.HasValueメソッドを使用することができます。
``` C#
int? i = 42;
Option<int> some1 = Maybe.HasValue(i);

i = null;
Option<int> none1 = Maybe.HasValue(i);

string s = "foo";
Option<string> some2 = Maybe.HasValue(s);

s = null;
Option<string> none2 = Maybe.HasValue(s);
```

Option<T>クラスのインスタンスに対しては、HasValueプロパティで値が存在するか取得できます。
また、Valueプロパティで値を取得できます。
``` C#
Option<int> some1 = Option.Some(42);
Console.WriteLine(some1.HasValue ? some1.Value : -1); // 42

Option<int> none1 = Option.None<int>();
Console.WriteLine(none1.HasValue ? none1.Value : -1); // -1

string s = "foo";
Option<string> some2 = Maybe.HasValue(s);
Console.WriteLine(some2.HasValue ? some2.Value : "bar"); // foo

s = null;
Option<string> none2 = Maybe.HasValue(s);
Console.WriteLine(none2.HasValue ? none2.Value : "bar"); // bar
```

値を持たないOption<T>クラスのインスタンスに対して、Valueプロパティで値を取得しようとした場合、InvalidOperationExceptionがスローされます。

``` C#
Option<int> none = Option.None<int>();
int i = none.Value; //throw an InvalidOperationException.
``` 

Option<T>クラスは、失敗するかもしれないメソッドの戻り値に使用します。
このライブラリでは、TryParse系メソッド、LINQの一部メソッド、Dictionaryから値を取得するメソッドについて、Option<T>を返すメソッドを定義しています。
``` C#
Option<int> some = Maybe.ParseInt32("42");
Console.WriteLine(some.HasValue ? some.Value : -1); // 42

Option<int> none = Maybe.ParseInt32("foo");
Console.WriteLine(none.HasValue ? none.Value : -1); // -1
``` 

ただし、Option<T>クラスでは、正常値としてのnull値を扱えません。
null値が格納されているDictionaryなどには注意してください。
``` C#
var dictionary = new Dictionary<string, string>()
{
	{ "foo", "bar" },
	{ "baz", null }
};

Option<string> some = dictionary.MaybeGetValue("foo");
Console.WriteLine(some.HasValue ? some.Value : "None"); // var

Option<string> none1 = Maybe.GetValue(dictionary, "baz");
Console.WriteLine(none1.HasValue ? none1.Value : "None"); // None

Option<string> none2 = Maybe.GetValue(dictionary, "foobar");
Console.WriteLine(none2.HasValue ? none2.Value : "None"); // None
```

HasValueプロパティをチェックしてValueプロパティにアクセスするのは面倒です。
Orメソッドで、値が存在する場合はその値を、存在しない場合はデフォルト値を取得できます。
``` C#
Console.WriteLine(Option.Some(42).Or(-1)); // 42
Console.WriteLine(Option.None<int>().Or(-1)); // -1

Console.WriteLine(Option.Some(42).Or(Option.Some(54)).Or(-1)); //42
Console.WriteLine(Option.None<int>().Or(Option.Some(54)).Or(-1)); //54
Console.WriteLine(Option.None<int>().Or(Option.None<int>()).Or(-1)); //-1
```

Bindメソッドで、値が存在する場合のみ処理を行うことができます。
``` C#
var some = Option.Some(42)
    .Bind(i => Option.Some(i * 2));
Console.WriteLine(some); // Some(84)

var none = Option.None<int>()
    .Bind(i => Option.Some(i * 2));
Console.WriteLine(none); // None
```

複数の値が存在する場合のみ処理を行う場合、Bindメソッドを使用すると面倒な場合があります。
LINQのクエリ式を悪用することにより、きれいに記述することができます。
``` C#
var result1 = Option.Some(42)
    .Bind(i1 => Option.Some(54)
        .Bind(i2 => Option.Some(i1.ToString() + i2.ToString())));
Console.WriteLine(result1); // Some(4254)

var result2 = from i1 in Option.Some(42)
              from i2 in Option.Some(54)
              select i1.ToString() + i2.ToString();
Console.WriteLine(result2); // Some(4254)
```


default(Option<T>)は、値を持たないインスタンスとなります。
``` C#
Option<int> none = default(Option<int>);
Console.WriteLine(none.HasValue); // false
``` 
