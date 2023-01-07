
using Serializer.App;
using Serializer.App.Entities;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

var student = new Student("Andrea", "Tosato", "AT2023")
{
    Votes = new List<Vote> { new Vote(8), new Vote(4), new Vote(6) }
};
WriteJson(student);

var uniStudent = new UniversityStudent("Andrea", "Tosato", "AT-UNI-2023")
{
    Votes = new List<Vote> { new UniversityVote("Analisi 1", 18), new UniversityVote("Chimica", 24), new UniversityVote("Fisica", 26) }
};
WriteJson(uniStudent);


void WriteJson(Person person)
{
    var option = new JsonSerializerOptions { WriteIndented = true };
    var jsonValue = JsonSerializer.Serialize(person, option);
    Console.WriteLine(jsonValue);
}


WriteMasked();
void WriteMasked()
{
    var options = new JsonSerializerOptions
    {
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { JsonSerializerModifiers.MaskMemberAttribute }
        }
    };

    var item = new LupinManager { Address = "Via Veneto, 99", PassCode = "PizzaKebab" };
    var result = JsonSerializer.Serialize(item, options);

    Console.WriteLine(result);
}