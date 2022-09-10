Coffee cup = PourCoffee();
Console.WriteLine("Coffee is ready");

Egg eggs = await FryEggsAsync(2);
Console.WriteLine("Eggs are ready");

Bacon bacon = await FryBaconAsync(3);
Console.WriteLine("Bacon is ready");

Toast toast = await ToastBreadAsync(2);
Console.WriteLine("Bread is ready");

Juice oj = PourOJ();
Console.WriteLine("Juice is ready");

Coffee PourCoffee()
{
    Console.WriteLine("Pouring Coffee");
    return new Coffee();
}

//private Task<Task<Egg>> GetEgg() { return new Egg(); }

async Task<Egg> FryEggsAsync(int v)
{
    Console.WriteLine("Heat the pan");
    Task.Delay(3000).Wait();
    Console.WriteLine($"Cooking {v} Eggs");
    Task.Delay(3000).Wait();
    Console.WriteLine("Put eggs on plate");

    return new Egg();
}

async Task<Bacon> FryBaconAsync(int quantity)
{
    Console.WriteLine($"Cooking {quantity} slices of bacon");
    Task.Delay(3000).Wait();
    Console.WriteLine("Put bacon on plate");

    return new Bacon();
}

async Task<Toast> ToastBreadAsync(int v)
{
    Console.WriteLine($"Put {v} slices of bread");
    Task.Delay(3000).Wait();
    Console.WriteLine("Put butter on toast");

    return new Toast();
}

Juice PourOJ()
{
    Console.WriteLine("Pouring orange juice");
    return new Juice();
}

