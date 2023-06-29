using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1234");

ISubscriber subscriber = connection.GetSubscriber();

await subscriber.SubscribeAsync("mychannel", (channel, value) => 
{
    Console.WriteLine($"{channel},  {value}");   

});

Console.Read();