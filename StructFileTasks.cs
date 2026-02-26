using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Lab3
{
    /// <summary>
    /// Структура для багажа пассажира (вариант 4)
    /// </summary>
    [Serializable]
    public struct LuggageItem
    {
        public string ItemName { get; set; }
        public double Weight { get; set; }

        public LuggageItem(string name, double weight)
        {
            ItemName = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{ItemName}: {Weight:F2} кг";
        }
    }

    [Serializable]
    public struct PassengerLuggage
    {
        public string PassengerName { get; set; }
        public List<LuggageItem> Items { get; set; }

        public PassengerLuggage(string name, List<LuggageItem> items)
        {
            PassengerName = name;
            Items = items;
        }

        public override string ToString()
        {
            string result = $"Пассажир: {PassengerName}\n";
            result += "Багаж:\n";

            foreach (var item in Items)
            {
                result += $"  - {item}\n";
            }

            result += $"  Всего единиц: {Items.Count}\n";
            return result;
        }
    }

    /// <summary>
    /// Задание 5: Работа с бинарными файлами и XML сериализацией
    /// Вариант 4: На сколько багаж максимальной массы отличается от багажа минимальной массы?
    /// </summary>
    public static class StructFileTasks
    {
        private static readonly string XmlFilePath = "luggage_data.xml";
        private static readonly string BinaryFilePath = "luggage_data.bin";
        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерация случайных данных о багаже и сохранение в XML
        /// </summary>
        public static void GenerateAndSaveToXml(int passengerCount)
        {
            List<PassengerLuggage> passengers = new List<PassengerLuggage>();

            string[] names = { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Васильев", "Михайлов" };
            string[] itemTypes = { "Чемодан", "Сумка", "Рюкзак", "Коробка", "Пакет" };

            for (int i = 0; i < passengerCount; i++)
            {
                string name = names[Random.Next(names.Length)] + " " + (char)('А' + Random.Next(0, 26));

                int itemCount = Random.Next(1, 6); // 1-5 предметов
                List<LuggageItem> items = new List<LuggageItem>();

                for (int j = 0; j < itemCount; j++)
                {
                    string itemName = itemTypes[Random.Next(itemTypes.Length)];
                    double weight = Math.Round(Random.NextDouble() * 30 + 1, 2); // 1-31 кг

                    items.Add(new LuggageItem(itemName, weight));
                }

                passengers.Add(new PassengerLuggage(name, items));
            }

            // XML сериализация
            XmlSerializer serializer = new XmlSerializer(typeof(List<PassengerLuggage>));

            using (FileStream fs = new FileStream(XmlFilePath, FileMode.Create))
            {
                using (XmlWriter writer = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true }))
                {
                    serializer.Serialize(writer, passengers);
                }
            }

            Console.WriteLine($"Сгенерированы данные о {passengerCount} пассажирах и сохранены в {XmlFilePath}");
        }

        /// <summary>
        /// Загрузка данных из XML и сохранение в бинарный файл
        /// </summary>
        public static void LoadFromXmlAndSaveToBinary()
        {
            if (!File.Exists(XmlFilePath))
            {
                throw new FileNotFoundException($"Файл {XmlFilePath} не найден");
            }

            // Десериализация из XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<PassengerLuggage>));
            List<PassengerLuggage> passengers;

            using (FileStream fs = new FileStream(XmlFilePath, FileMode.Open))
            {
                passengers = (List<PassengerLuggage>)serializer.Deserialize(fs);
            }

            // Сохранение в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(BinaryFilePath, FileMode.Create)))
            {
                foreach (var passenger in passengers)
                {
                    writer.Write(passenger.PassengerName);
                    writer.Write(passenger.Items.Count);

                    foreach (var item in passenger.Items)
                    {
                        writer.Write(item.ItemName);
                        writer.Write(item.Weight);
                    }
                }
            }

            Console.WriteLine($"Данные сохранены в бинарный файл {BinaryFilePath}");
        }

        /// <summary>
        /// Вывод данных о багаже из бинарного файла
        /// </summary>
        public static void PrintBinaryLuggageData()
        {
            if (!File.Exists(BinaryFilePath))
            {
                Console.WriteLine($"Файл {BinaryFilePath} не найден");
                return;
            }

            Console.WriteLine("\nДанные о багаже пассажиров:");
            Console.WriteLine("=============================");

            using (BinaryReader reader = new BinaryReader(File.Open(BinaryFilePath, FileMode.Open)))
            {
                int passengerIndex = 1;

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    int itemCount = reader.ReadInt32();

                    Console.WriteLine($"\nПассажир {passengerIndex}: {name}");

                    double totalWeight = 0;

                    for (int i = 0; i < itemCount; i++)
                    {
                        string itemName = reader.ReadString();
                        double weight = reader.ReadDouble();

                        Console.WriteLine($"  {i + 1}. {itemName}: {weight:F2} кг");
                        totalWeight += weight;
                    }

                    Console.WriteLine($"  Общий вес: {totalWeight:F2} кг");
                    Console.WriteLine($"  Средний вес единицы: {totalWeight / itemCount:F2} кг");

                    passengerIndex++;
                }
            }
        }

        /// <summary>
        /// Задание 5.4: На сколько багаж максимальной массы отличается от багажа минимальной массы?
        /// </summary>
        public static double CalculateWeightDifference()
        {
            if (!File.Exists(BinaryFilePath))
            {
                throw new FileNotFoundException($"Файл {BinaryFilePath} не найден");
            }

            List<double> totalWeights = new List<double>();

            using (BinaryReader reader = new BinaryReader(File.Open(BinaryFilePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Пропускаем имя
                    reader.ReadString();

                    int itemCount = reader.ReadInt32();
                    double totalWeight = 0;

                    for (int i = 0; i < itemCount; i++)
                    {
                        // Пропускаем название
                        reader.ReadString();
                        totalWeight += reader.ReadDouble();
                    }

                    totalWeights.Add(totalWeight);
                }
            }

            if (totalWeights.Count == 0)
            {
                throw new InvalidOperationException("Нет данных о пассажирах");
            }

            double maxWeight = totalWeights.Max();
            double minWeight = totalWeights.Min();
            double difference = maxWeight - minWeight;

            Console.WriteLine($"\nМаксимальный вес багажа: {maxWeight:F2} кг");
            Console.WriteLine($"Минимальный вес багажа: {minWeight:F2} кг");

            return difference;
        }

        /// <summary>
        /// Запуск задания 5
        /// </summary>
        public static void RunTask5()
        {
            try
            {
                // Генерируем данные и сохраняем в XML
                GenerateAndSaveToXml(5);

                // Загружаем из XML и сохраняем в бинарный файл
                LoadFromXmlAndSaveToBinary();

                // Выводим данные
                PrintBinaryLuggageData();

                // Вычисляем разницу между максимальным и минимальным багажом
                double difference = CalculateWeightDifference();

                Console.WriteLine($"\nРазница между максимальным и минимальным багажом: {difference:F2} кг");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}