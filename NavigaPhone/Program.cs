using System;
using System.Collections.Generic;

namespace NavigaPhone
{
    class Program
    {
        static void Main()
        {
            var text = new Text("bonjour");
            var blabla = new Text("blabla");
            var comment = new Comment("tada");

            var elem = new ElementData("p", new Dictionary<string, string> {{"class", "salut"}}, new List<Node> {text});
            var bold = new ElementData("b", new Dictionary<string, string>(), new List<Node> { blabla });
            var root = new ElementData("html", new Dictionary<string, string>(), new List<Node> {bold, comment, elem});

            root.PrettyPrint();

            Console.ReadLine();
        }
    }
}
