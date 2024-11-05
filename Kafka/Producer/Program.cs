using Confluent.Kafka;
using System;
using System.IO;
using System.Threading.Tasks;
using Avro;
using Avro.Generic;
using Avro.IO;

namespace Producer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Определяем Avro-схему
            string schemaJson = @"
            {
                ""type"": ""record"",
                ""name"": ""Order"",
                ""fields"": [
                    {""name"": ""order_id"", ""type"": ""int""},
                    {""name"": ""dishes"", ""type"": ""string""},
                    {""name"": ""total_cost"", ""type"": { ""type"": ""bytes"", ""logicalType"": ""decimal"", ""precision"": 16, ""scale"": 4,}},
                    {""name"": ""created_at"", ""type"":{ ""type"": ""long"", ""logicalType"": ""timestamp-millis""}}
                ]
            }";

            // Парсим Avro-схему
            Schema schema = Schema.Parse(schemaJson);

            // Создаем объект GenericRecord на основе Avro-схемы
            var user = new GenericRecord((RecordSchema)schema);
            user.Add("order_id", 1);
            user.Add("dishes", "Блюда>");
            user.Add("total_cost", 22.2f);
            user.Add("created_at", DateTime.Now);

            // Сериализуем данные в Avro-формат
            byte[] avroData;
            using (var ms = new MemoryStream())
            {
                var writer = new BinaryEncoder(ms);
                var datumWriter = new GenericDatumWriter<GenericRecord>(schema);
                datumWriter.Write(user, writer);
                avroData = ms.ToArray();
            }

            // Конфигурация Kafka продюсера
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092" // Укажите адрес вашего Kafka брокера
            };

            // Отправка сообщения в Kafka
            using (var producer = new ProducerBuilder<Null, byte[]>(producerConfig).Build())
            {
                var message = new Message<Null, byte[]>
                {
                    Value = avroData
                };

                var deliveryResult = producer.ProduceAsync("test-topic", message).GetAwaiter().GetResult();

                Console.WriteLine($"Message delivered to {deliveryResult.TopicPartitionOffset}");
            }
        }
    }
}