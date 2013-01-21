using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Xml.XPath;
using CSTruter.com.XQuery;

namespace CSTruter.com
{
    public class functions
    {
        [SqlFunction]
        public static bool XQuery([SqlFacet(MaxSize = -1)]String value, String expression)
        {
            if (!String.IsNullOrEmpty(value))
            {
                using (StringReader sr = new StringReader(value))
                {
                    XPathDocument doc = new XPathDocument(sr);
                    XPathNavigator nav = doc.CreateNavigator();
                    CustomContext ctx = new CustomContext();
                    XPathExpression expr = nav.Compile(expression);
                    expr.SetContext(ctx);
                    XPathNodeIterator nodes = nav.Select(expr);
                    return nodes.Count > 0;
                }
            }
            return false;
        }
    }
}
