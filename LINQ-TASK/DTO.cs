using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQ_TASK
{
    class DTO
    {
        public static List<string> read_from_file(string path_to_file)
        {
            FileStream datum = new FileStream(path_to_file, FileMode.Open);
            StreamReader reader = new StreamReader(datum);
            var output_datum = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();

            return output_datum;
        }

        
       public static void write_to_file(string path_to_file, IEnumerable<string> input_datum)
        {
            FileStream datum = new FileStream(path_to_file, FileMode.Create);
            StreamWriter writer = new StreamWriter(datum);
            foreach (var item in input_datum)
            {
                writer.Write($"{item} ");
            }
            writer.Close();
        }
    }
}
