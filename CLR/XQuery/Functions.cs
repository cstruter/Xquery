using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CSTruter.com.XQuery
{
    public class UpperCase : IXsltContextFunction
    {
        public UpperCase()
        {
        }

        public XPathResultType[] ArgTypes
        {
            get { return null; }
        }

        public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
        {
            return args[0].ToString().ToUpper();
        }

        public int Maxargs
        {
            get { return 1; }
        }

        public int Minargs
        {
            get { return 1; }
        }

        public XPathResultType ReturnType
        {
            get { return XPathResultType.String; }
        }
    }
}
