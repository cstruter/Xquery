using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using CSTruter.com.XQuery;

namespace CSTruter.com
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument(@"items.xml");
            XPathNavigator nav = doc.CreateNavigator();
            CustomContext ctx = new CustomContext();

            XPathExpression expr = nav.Compile(@"*//item[contains(upper-case(string(@value)), 'AB')]");
            expr.SetContext(ctx);
            XPathNodeIterator nodes = nav.Select(expr);
            foreach (XPathItem node in nodes)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
