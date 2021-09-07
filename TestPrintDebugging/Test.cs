using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace TestPrintDebugging
{
    public class Test
    {
        private readonly ITestOutputHelper _output; 

        public Test(ITestOutputHelper output)
        {
            _output = output; //Konstruktorn och classen gör att man får ett outputfönster i xUnit.
        }

        [Fact]
        public void MyTest()
        {
            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(new Visitor("Henry Ford"));
            visitors.Add(new Visitor("Victoria"));

            for (int i = visitors.Count - 1; i >= 0; i--)
            {
                Visitor visitor = visitors[i];
                _output.WriteLine($"i={i}, visitor={visitor.Name}");
            }
        }
    }
    class Visitor
    {
        public string Name;

        public Visitor(string name)
        {
            Name = name;
        }
    }
}

