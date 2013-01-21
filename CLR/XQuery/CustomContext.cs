using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace CSTruter.com.XQuery
{
    public class CustomContext : XsltContext
    {
        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            if (name == "upper-case")
            {
                return new UpperCase();
            }
            return null;
        }

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            throw new NotImplementedException();
        }

        public override bool PreserveWhitespace(XPathNavigator node)
        {
            throw new NotImplementedException();
        }

        public override IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            throw new NotImplementedException();
        }

        public override bool Whitespace
        {
            get { throw new NotImplementedException(); }
        }
    }
}
