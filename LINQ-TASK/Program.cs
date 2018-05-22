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

            IEnumerable<string> answer = numbers.Where(number => Int32.Parse(number) > 0);

            DTO.write_to_file("answer.txt", answer);
        }

        static void Task17()
        {
            List<string> numbers = DTO.read_from_file("data17.txt");

            IEnumerable<string> answer = numbers.Where(number => (Int32.Parse(number) % 2 == 1 || Int32.Parse(number) % 2 == -1)).Distinct();

            DTO.write_to_file("answer17.txt", answer);
        }

        static void Task18()
        {
            List<string> numbers = DTO.read_from_file("data18.txt");

            IEnumerable<string> answer = numbers.OrderBy(number => Int32.Parse(number)).Where(number => ((number.StartsWith("-") == false) && (number.Length == 2)));

            DTO.write_to_file("answer18.txt", answer);
        }

        static void Task19()
        {
            List<string> words = DTO.read_from_file("data19.txt");

            IEnumerable<string> answer = words.OrderBy(word => word.Length).ThenByDescending(word => word);

            DTO.write_to_file("answer19.txt", answer);
        }

      
        static void Task20()
        {
            FileStream datum = new FileStream("data20.txt", FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            int D = Int32.Parse(reader.ReadLine());
            List<string> numbers = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();

            IEnumerable<string> answer_numbers = numbers.SkipWhile(number => Int32.Parse(number) <= D).Reverse().Where(number => Int32.Parse(number) % 2 == 1);

            FileStream answer = new FileStream("answer20.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(answer);
            foreach (var number in answer_numbers)
            {
                writer.Write($"{number} ");
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
        }
    }
}
