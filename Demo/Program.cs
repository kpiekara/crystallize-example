using Demo;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
    .Addcatalogue()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://workshop.chillicream.com/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

var client = services.GetRequiredService<Icatalogue>();

var result = await client.GetItem.ExecuteAsync("", "");
result.EnsureNoErrors();

Console.WriteLine(result.Data.Catalogue);