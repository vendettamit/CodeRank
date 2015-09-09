using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CSharp;

namespace SampleTestRule
{
    class SampleViewModel
    {
        static void Main(string[] args)
        {
            string code = @"
             namespace foo {
                 public class DynamicTypeA { }
                 public class DynamicTypeB {
                     public DynamicTypeA MyProperty { get; set; } 
                 }
             }       
        ";

            CSharpCodeProvider csp = new CSharpCodeProvider();

            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;

            var results = csp.CompileAssemblyFromSource(p, code);

            foreach (Type type in results.CompiledAssembly.GetTypes())
            {
                Console.WriteLine(type.Name);

                foreach (PropertyInfo pi in type.GetProperties())
                {
                    Console.WriteLine("\t{0}", pi.PropertyType.Name);
                }
            }

            Console.ReadLine();

        }

        void Anothor()
        {
            string code = @"
             using System;
             using System.Reflection; 
             namespace foo {
                 public class DynamicTypeA { }
                 public class DynamicTypeB {
                     public DynamicTypeA MyProperty { get; set; } 
                 }

                 public class DynamicTypeC {
                     public void Foo() {
                        foreach ( PropertyInfo pi in typeof(DynamicTypeB).GetProperties() )
                        {
                            Console.WriteLine( pi.PropertyType.Name );
                        }
                     } 
                 }
             }       
        ";

            CSharpCodeProvider csp = new CSharpCodeProvider();

            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;

            var results = csp.CompileAssemblyFromSource(p, code);

            var c = results.CompiledAssembly.CreateInstance("foo.DynamicTypeC");
            var typeC = c.GetType();

            typeC.InvokeMember("Foo", BindingFlags.InvokeMethod |
                BindingFlags.Public | BindingFlags.Instance, null, c, null);
        }
    }
}
