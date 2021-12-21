using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Root.ReadFileAsync("json1.json");
            while (!items.IsCompleted) { }
            Print(items.Result);
        }

        public static void Print(IEnumerable<Root> items)
        {
            foreach (var item in items.OrderByDescending(sel => sel.SumDayWork()))
            {
                Console.WriteLine($"{item.name}; {item.SumDayWork()}");
            }
        }
    }
}