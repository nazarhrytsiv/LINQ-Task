using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace LINQ_TASK
{

    class Program
    {
        
        static void Task16()
        {
            List<string> numbers = DTO.read_from_file("data.txt");
            var answer = numbers.Where(number => Int32.Parse(number) > 0);
            DTO.write_to_file("out1.txt", answer);
        }

        static void Task17()
        {
            List<string> numbers = DTO.read_from_file("data17.txt");
            var answer = numbers.Where(number => (Int32.Parse(number) % 2 == 1 || Int32.Parse(number) % 2 == -1)).Distinct();
            DTO.write_to_file("out17.txt", answer);
        }

        static void Task18()
        {
            List<string> numbers = DTO.read_from_file("data18.txt");
            var answer = numbers.OrderBy(number => Int32.Parse(number)).Where(number => ((number.StartsWith("-") == false) && (number.Length == 2)));
            DTO.write_to_file("out18.txt", answer);
        }

        static void Task19()
        {
            List<string> words = DTO.read_from_file("data19.txt");
            var answer = words.OrderBy(word => word.Length).ThenByDescending(word => word);
            DTO.write_to_file("out19.txt", answer);
        }

      
        static void Task20()
        {
            FileStream datum = new FileStream("data20.txt", FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            int D = Int32.Parse(reader.ReadLine());
            List<string> numbers = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();
            var answer_numbers = numbers.SkipWhile(number => Int32.Parse(number) <= D).Reverse().Where(number => Int32.Parse(number) % 2 == 1);
            DTO.write_to_file("out20.txt", answer_numbers);
        }

        static void Task44()
        {
            FileStream datum = new FileStream("data44.txt", FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            int K1 = Convert.ToInt32(reader.ReadLine());
            int K2 = Convert.ToInt32(reader.ReadLine());
            List<string> a = reader.ReadLine().Split(' ').ToList();
            List<string> b = reader.ReadLine().Split(' ').ToList();
            reader.Close();
            var listA = a.Where(n => Int32.Parse(n) > K1);
            var listB = b.Where(n => Int32.Parse(n) < K2);
            var answer = listA.Concat(listB).OrderBy(n => Int32.Parse(n));
            DTO.write_to_file("out44.txt", answer);
            
        }

        static void Task45()
        {
            FileStream datum = new FileStream("data45.txt", FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            int L1 = Convert.ToInt32(reader.ReadLine());
            int L2 = Convert.ToInt32(reader.ReadLine());
            List<string> a = reader.ReadLine().Split(' ').ToList();
            List<string> b = reader.ReadLine().Split(' ').ToList();
            reader.Close();
            var listA = a.Where(x => x.Length == L1);
            var listB = b.Where(x => x.Length == L2);
            var answer = listA.Concat(listB).OrderByDescending(n => n);
            DTO.write_to_file("out45.txt", answer);
        }

        static void TaskLast()
        {
            FileStream datum = new FileStream("dataLast.txt", FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            int len = Int32.Parse(reader.ReadLine());
            List<Client> clients = Client.read_from_file(reader, len);
            reader.Close();
            FileStream datum_out = new FileStream("outLast.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(datum_out);
            writer.WriteLine($"Min duration: {Client.find_shorted_duration(clients).Code}");
            writer.WriteLine($"Year with the biggest sum: {Client.find_year(clients)}");
            writer.WriteLine($"Max duration: {Client.find_longest_duration(clients).Code}");
            SortedDictionary<int, int> durations = Client.sum_durations(clients);
            writer.WriteLine("Sum of durations:");
            foreach (var answer in durations)
            {
                writer.WriteLine($"Value - {answer.Value}, duration - {answer.Key}");
            }
            SortedDictionary<int, int> months = Client.count_months(clients);
            writer.WriteLine("Count of mounths:");
            foreach (var item in months)
            {
                writer.WriteLine($"code - {item.Value}, count - {item.Key}");
            }
            writer.Close();

        }
            static void Main(string[] args)
        {
            Task16();
            Task17();
            Task18();
            Task19();
            Task20();
            Task44();
            Task45();
            TaskLast();
        }
    }
}
