using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Events;
using ProductService.Application.Interfaces;

public class OrderCreatedConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OrderCreatedConsumer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Product Service Consumer Started...");

       
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672
        };

        await using var connection = await factory.CreateConnectionAsync(stoppingToken);

        
        await using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

        await channel.QueueDeclareAsync(
            queue: "order_created",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: stoppingToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, args) =>
        {
            var body = args.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var orderEvent = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

            if (orderEvent != null)
            {
                using var scope = _scopeFactory.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<IProductServiceRepository>();

                var product = await repo.GetByIdAsync(orderEvent.ProductId);
                if (product != null)
                {
                    product.ReduceStock(orderEvent.Quantity);
                    await repo.UpdateAsync(product); // update stock
                    Console.WriteLine($"Stock updated for Product {product.Id}");
                }
            }

         
            await channel.BasicAckAsync(args.DeliveryTag, false, stoppingToken);
        };

      
        await channel.BasicConsumeAsync(
            queue: "order_created",
            autoAck: false,
            consumer: consumer,
            cancellationToken: stoppingToken);

        await Task.Delay(-1, stoppingToken);
    }
}
