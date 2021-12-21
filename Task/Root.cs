using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task
{
    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Position> positions { get; set; }
        public static async Task<IEnumerable<Root>> ReadFileAsync(string filename)
        {
            using FileStream fs = new FileStream(filename, FileMode.Open);
            var restoredPerson = await JsonSerializer.DeserializeAsync<Root[]>(fs);
            return restoredPerson;
        }
        public int SumDayWork()
        {
            int Sum = 0;
            for(int i = 0; i < positions.Count; i++)
            {
                DateTime from = DateTime.Parse(positions[i].from);
                if (positions[i].to == null)
                {
                    Sum = Sum + (int)Math.Ceiling((DateTime.Now - from).TotalDays);
                }
                else
                {
                    DateTime to = DateTime.Parse(positions[i].to);
                    Sum = Sum + (int)Math.Ceiling((to - from).TotalDays);
                }
            }
            return Sum;

        }
    }


}
