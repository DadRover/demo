using System;
using System.Threading;
using Confluent.Kafka;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Конфигурация Consumer
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "test-consumer-group", // Укажите группу потребителей
                BootstrapServers = "localhost:9092", // Адрес вашего Kafka брокера
                AutoOffsetReset = AutoOffsetReset.Earliest, // Начинаем с самого раннего сообщения
                EnableAutoCommit = true // Включаем автоматическую фиксацию оффсетов
            };

            // Создание Consumer для чтения сообщений
            using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                consumer.Subscribe("test-topic"); // Подписка на топик Kafka

                Console.WriteLine("Waiting for messages...");

                // Бесконечный цикл чтения сообщений
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(CancellationToken.None);

                        // Вывод сообщения
                        Console.WriteLine(
                            $"Received message: {consumeResult.Message.Value} at {consumeResult.TopicPartitionOffset}");
                    }
                    catch (ConsumeException e)
                    {
                        // Обработка ошибки потребления сообщения
                        Console.WriteLine($"Error occurred: {e.Error.Reason}");
                    }
                }
            }
        }
    }
}