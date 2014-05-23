using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maybe.Parse.Generate
{
    class Program
    {
        static void Main(string[] args)
        {
            var typeNames = new[] { "Byte", "Int16", "Int32", "Int64", "Single", "Double", "Decimal" };

            Directory.CreateDirectory("Output");

            foreach (var typeName in typeNames)
            {
                var filePath = Path.Combine("Output",
                    string.Format("Maybe.Parse{0}.cs", typeName));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    var mp = new Maybe_ParseNumber() { TypeName = typeName };
                    writer.Write(mp.TransformText());
                }
            }
        }
    }
}
