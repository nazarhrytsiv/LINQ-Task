using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LINQ_TASK
{
    class Client
    {
        public int Code { get; set; }
        public int Year { get; set; }
        public int Mounth { get; set; }
        public int Duration_of_classes { get; set; }
        public void read_from_file_to_client(StreamReader reader)
        {
            var list = reader.ReadLine().Split(' ').ToList().Select(Int32.Parse).ToList();
            this.Code = list[0];
            this.Year = list[1];
            this.Mounth = list[2];
            this.Duration_of_classes = list[3];
        }
        
        public static Client find_longest_duration(List<Client> clients)
        {
            int duration = clients.Max(x => x.Duration_of_classes);
            Client client_longest_duration = clients.First(x => x.Duration_of_classes == duration);
            return client_longest_duration;
        }

        public static Client find_shorted_duration(List<Client> clients)
        {
            int duration = clients.Min(item => item.Duration_of_classes);
            Client client_shorted_duration = clients.First(item => item.Duration_of_classes == duration);
            return client_shorted_duration;
        }

        public static int find_year(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> group_year = clients.GroupBy(item => item.Year);
            IEnumerable<IGrouping<int, Client>> sorted = group_year.OrderByDescending(group => group.Sum(client => client.Duration_of_classes)).ThenBy(x => x.Min(y => y.Year));
            return sorted.First().Key;
        }

        public static SortedDictionary<int, int> sum_durations(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> group_by = clients.GroupBy(item => item.Code);
            SortedDictionary<int, int> durations = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> group in group_by)
            {
                int sum = group.Sum(x => x.Duration_of_classes);
                durations.Add(sum, group.Key);
            }

            return durations;
        }

        public static SortedDictionary<int, int> count_months(List<Client> clients)
        {
            IEnumerable<IGrouping<int, Client>> group_by_months = clients.GroupBy(item => item.Code);
            SortedDictionary<int, int> months = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> groups in group_by_months)
            {
                int count = groups.Count();
                months.Add(count, groups.Key);
            }

            return months;
        }

        public static List<Client> read_from_file(StreamReader reader, int len)
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < len; i++)
            {
                Client client = new Client();
                client.read_from_file_to_client(reader);
                clients.Add(client);
            }
            return clients;
        }
    }
}
