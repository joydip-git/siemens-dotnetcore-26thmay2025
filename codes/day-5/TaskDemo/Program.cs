
//Action task = () => Console.WriteLine("hello task");
//Task.Run(task);

/*
Task t = Task.Run(() =>
{
    //Console.WriteLine(Environment.CurrentManagedThreadId);
    //Thread.Sleep(1000);
    Console.WriteLine("hello");
}
);
if (t.IsCompleted)
{
    if (t.IsCompletedSuccessfully)
        Console.WriteLine("done...");
}
else
{
    Console.WriteLine("not done...");
}
*/

using System.Net.Http.Json;

try
{
    bool isEven = await IsEven(3);
    await PrintTask<int>(3);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Post? post = await GetPostsAsync();
Console.WriteLine(post?.Title);

static async Task PrintTask<T>(T data)
{
    Console.WriteLine(data);
}
static async Task<bool> IsEven(int number)
{
    return number % 2 == 0;
}
static async Task<Post?> GetPostsAsync()
{
    try
    {
        var client = new HttpClient();
        return await client.GetFromJsonAsync<Post>("https://jsonplaceholder.typicode.com/posts/1");
    }
    catch (Exception)
    {
        throw;
    }
}

class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}


