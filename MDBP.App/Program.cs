// See https://aka.ms/new-console-template for more information

using MusicDBPlayground.DiscogsIntegration;
using MusicDBPlayground.DiscogsIntegration.Security;

Console.WriteLine("Hello, World!");
Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
using var client = new HttpClient();
var discogsClient = new DiscogsOAuthClient(client);
var result = await discogsClient.AuthorizeWithOAuth1();



Console.WriteLine(result.Token);
Console.WriteLine(result.TokenSecret);


Console.ReadLine();
Console.WriteLine("Done!");