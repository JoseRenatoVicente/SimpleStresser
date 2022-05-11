
var tasks = new List<Task<HttpResponseMessage>>();
int numberOfRequests = 2000;

Parallel.For(0, numberOfRequests, count =>
{
    tasks.Add(MakeRequestAsync(new("https://example.com")));
});

Console.WriteLine("End");


async Task<HttpResponseMessage> MakeRequestAsync(Uri uri)
{
    try
    {
        using var httpClient = new HttpClient();

        return await httpClient.GetAsync(uri);
    }
    catch
    {
        return new HttpResponseMessage();
    }
}