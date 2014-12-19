using System;
using System.Collections.Generic;
using System.Linq;

namespace NavigaPhone
{
    public abstract class Node
    {
        protected List<Node> Children;

        public abstract void PrettyPrint(int nbTabs = 0);

        public string PrintTabs(int nb = 0)
        {
            var tabs = "";
            
            for (var i = 0; i < nb; i++)
            {
                tabs += "    ";
            }

            return tabs;
        }
    }

    public class Text : Node
    {
        readonly string _value;

        public Text(string data)
        {
            _value = data;
            Children = new List<Node>();
        }

        public override void PrettyPrint(int nbTabs = 0)
        {
            Console.Write(PrintTabs(nbTabs) + _value + "\n");
        }
    }

    public class ElementData : Node
    {
        readonly string _tagName;
        readonly Dictionary<string, string> _attributes;

        public ElementData(string tagName, Dictionary<string, string> attributes, List<Node> children)
        {
            _tagName = tagName;
            _attributes = attributes;
            Children = children;
        }

        public override void PrettyPrint(int nbTabs = 0)
        {
            Console.Write(PrintTabs(nbTabs) + "<" + _tagName + PrintAttributes() + ">" + "\n");

            foreach(var node in Children)
            {
                node.PrettyPrint(nbTabs + 1);
            }

            Console.Write(PrintTabs(nbTabs) + "</" + _tagName + ">" + "\n");
        }

        private string PrintAttributes()
        {
            return _attributes.Aggregate("", (current, pair) => current + (" " + pair.Key + " = \"" + pair.Value + "\""));
        }
    }

    public class Comment : Node
    {
        readonly string _value;

        public Comment(string data)
        {
            _value = data;
            Children = new List<Node>();
        }

        public override void PrettyPrint(int nbTabs = 0)
        {
            Console.Write(PrintTabs(nbTabs) + "<!-- " + _value + " -->" + "\n");
        }
    }
}
