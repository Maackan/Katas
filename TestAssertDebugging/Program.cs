using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestAssertDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(new Visitor("Henry Ford"));
            visitors.Add(new Visitor("Victoria"));
            visitors.Add(new Visitor("Markus Andersson"));

            for (int i = visitors.Count - 1; i >= 0; i--)
            {
                Visitor visitor = visitors[i];
                Debug.Assert(visitor.Name != null, "Namnet saknas");
                Debug.Assert(visitor.Name.Length > 4, "Namnet är för kort");
                Debug.Assert(visitor.Name.Contains(' '), "Namn saknar mellanslag");
                Debug.Assert(visitors != null);
                
                //Lägger in småtester i sitt program.
            }
        }
    }
}
