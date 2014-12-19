using System;
using System.Collections.Generic;

namespace NavigaPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text("bonjour");
            var properties = new Dictionary<string, string>();
            var content = new List<Node>();

            properties.Add("class", "salut");
            content.Add(text);

            var elem = new ElementData("p", properties, content);

            elem.PrettyPrint();

            Console.ReadLine();
        }
    }
}
