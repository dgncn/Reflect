using Reflect.Entities;

F1Car f1Car = new F1Car(Team: "McLaren");
Console.WriteLine(f1Car.Team);
var assemblyName = "Reflect";
var typeName = "Reflect.F1Car";
try
{
    var car = Activator.CreateInstance(typeof(F1Car)); // parametresiz nesne üretir hata fırlatır throws

    var car2 = Activator.CreateInstance(assemblyName, typeName); // parametresiz nesne üretir hata fırlatır throws
}
catch (Exception)
{
    Console.WriteLine("Bu hatalar bizi yildirmaz, gec kardesim bunlari.");
}
var car3 = Activator.CreateInstance(typeof(F1Car), new object[] { "HAAS" }) as F1Car; // Team parametresine HAAS değerini geçerek nesne üretir. parametreli constructor çağrısı yapar
Console.WriteLine(car3!.Team);


namespace Reflect.Entities
{
    public record F1Car(string Team);
}