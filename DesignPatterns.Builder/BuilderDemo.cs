using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

/// <summary>
/// When peicewise object construction is complicated provide an API for doing it succintly
/// </summary>
namespace DesignPatterns.Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text)); ;
        }

        private string ToStringImpl(int indent) 
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if(!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach(var e in Elements)
            {
                // nested indentation for each of the inner htmlElement
                sb.Append(e.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            this.rootName = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }


    public class BuilderDemo
    {
        /// <summary>
        /// Suppose we want a simple html paragraph <p> with a list in it
        /// The problem is that we are making too much effort here.  
        /// We would rather create Builder, which represents a tree of HTML elements that we can manipulate, traverse, etc.
        /// </summary>
        public static void TestExampleWithoutBuilder()
        {
            var hi = "hi";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hi);
            sb.Append("</p>");
            WriteLine(sb);

            var words = new[] { "hi", "programmer" };
            sb.Clear();
            sb.Append("<ul>");
            foreach(var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>", word);
            }
            sb.Append("<ul>");
            WriteLine(sb);
        }

        public static void UseBuilder()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hi");
            builder.AddChild("li", "programmer");
            WriteLine(builder.ToString()); 

        }

    }
}
