// See https://aka.ms/new-console-template for more information

async Task<List<int>> A()
{
    await Task.Delay(4 * 1000);
    Console.WriteLine("await");
    return new List<int>();
}

var a = A();

(await a).Add(1);
(await a).Add(2);
(await a).Add(3);
(await a).Add(4);
(await a).Remove(2);


Console.WriteLine((await a).Count);
