using Reflect.Entities;
using System.Reflection;

//F1Car f1Car = new F1Car(Team: "McLaren");
//Console.WriteLine(f1Car.Team);
//var assemblyName = "Reflect";
//var typeName = "Reflect.F1Car";
//try
//{
//    var car = Activator.CreateInstance(typeof(F1Car)); 

//    var car2 = Activator.CreateInstance(assemblyName, typeName);
//}
//catch (Exception)
//{
//    Console.WriteLine("Bu hatalar bizi yildirmaz, gec kardesim bunlari.");
//}
var car3 = Activator.CreateInstance(typeof(F1Car), new object[] { "HAAS" }) as F1Car; 
//Console.WriteLine(car3!.Team);

MemberInfo info = typeof(F1Car);
//info.GetInformations();


//Ext.PrintAssemblyInfo(info);
//Ext.PrintAssemblyInfo();
Ext.PrintMethods(typeof(Ext));
Ext.PrintMethods(info);
Ext.PrintMethods(car3!);

namespace Reflect.Entities
{
    public record F1Car(string Team);

    public static class Ext
    {
        public static void GetInformations(this MemberInfo info)
        {
            string message = $"info.Name: {info.Name} info.MemberType: {info.MemberType}";
            Console.WriteLine(message);
        }

        public static void PrintAssemblyInfo(object o)
        {
            var assembly = o.GetType().Assembly;
            Console.WriteLine(assembly.FullName);
        }

        public static void PrintAssemblyInfo()
        {
            var assembly = typeof(string).Assembly;
            Console.WriteLine(assembly.Modules.Select(x => x.ScopeName));
        }

        internal static void PrintMethods(object obj)
        {
            if (obj is Type)
            {
                foreach (var methodInfo in (obj as Type).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Where(x => x.IsAssembly))
                {
                    Console.WriteLine(methodInfo.Name);
                }
            }
            else
            {
                var objType = obj.GetType();
                foreach (var methodInfo in objType.GetMethods())
                {
                    Console.WriteLine(methodInfo.Name);
                }
            }
            Console.WriteLine("==============");
        }
    }
}