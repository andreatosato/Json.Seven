using Database.App;
using Microsoft.EntityFrameworkCore;

await using var context = new DataContext();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await context.RunSeed();
Console.Clear();
Console.WriteLine("Created Seed");


#region AuthorsInChigley
var authorsInChigley = await context.Authors
    .Where(author => author.Contact.Address.City == "Chigley")
    .ToListAsync();
#endregion

Console.WriteLine();
foreach (var author in authorsInChigley)
{
    Console.WriteLine($"{author.Name} lives at '{author.Contact.Address.Street}' in Chigley.");
}

Console.WriteLine();

#region PostcodesInChigley
var postcodesInChigley = await context.Authors
    .Where(author => author.Contact.Address.City == "Chigley")
    .Select(author => author.Contact.Address.Postcode)
    .ToListAsync();
#endregion

Console.WriteLine();
Console.WriteLine($"Postcodes in Chigley are '{string.Join("', '", postcodesInChigley)}'");
Console.WriteLine();

#region OrderedAddresses
var orderedAddresses = await context.Authors
    .Where(
        author => (author.Contact.Address.City == "Chigley"
                   && author.Contact.Phone != null)
                  || author.Name.StartsWith("D"))
    .OrderBy(author => author.Contact.Phone)
    .Select(
        author => author.Name + " (" + author.Contact.Address.Street
                  + ", " + author.Contact.Address.City
                  + " " + author.Contact.Address.Postcode + ")")
    .ToListAsync();
#endregion

Console.WriteLine();
foreach (var address in orderedAddresses)
{
    Console.WriteLine(address);
}

Console.WriteLine();

context.ChangeTracker.Clear();

Console.WriteLine("Updating a 'Contact' JSON document...");
Console.WriteLine();

#region UpdateDocument
var jeremy = await context.Authors.SingleAsync(author => author.Name.StartsWith("Jeremy"));

jeremy.Contact = new() { Address = new("2 Riverside", "Trimbridge", "TB1 5ZS", "UK"), Phone = "01632 88346" };

await context.SaveChangesAsync();
#endregion

context.ChangeTracker.Clear();

Console.WriteLine("Updating an 'Address' inside the 'Contact' JSON document...");
Console.WriteLine();

#region UpdateSubDocument
var brice = await context.Authors.SingleAsync(author => author.Name.StartsWith("Brice"));

brice.Contact.Address = new("4 Riverside", "Trimbridge", "TB1 5ZS", "UK");

await context.SaveChangesAsync();
#endregion

