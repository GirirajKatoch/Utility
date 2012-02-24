using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Utility.Xml
{
    /// <summary>
    /// http://jacobcarpenter.wordpress.com/2010/01/07/reading-large-xml-files/
    /// </summary>
    public static class XmlReaderExtensions
    {
        /// <summary>
        /// Returns a sequence of <see cref="XElement">XElements</see> corresponding to the currently
        /// positioned element and all following sibling elements which match the specified name.
        /// </summary>
        /// <param name="reader">The xml reader positioned at the desired hierarchy level.</param>
        /// <param name="elementName">An <see cref="XName"/> representing the name of the desired element.</param>
        /// <returns>A sequence of <see cref="XElement">XElements</see>.</returns>
        /// <remarks>At the end of the sequence, the reader will be positioned on the end tag of the parent element.</remarks>
        public static IEnumerable<XElement> ReadXElements(this XmlReader reader, XName elementName)
        {
            if (reader.Name == elementName.LocalName && reader.NamespaceURI == elementName.NamespaceName)
                yield return (XElement)XElement.ReadFrom(reader);

            while (reader.ReadToNextSibling(elementName.LocalName, elementName.NamespaceName))
                yield return (XElement)XElement.ReadFrom(reader);
        }
    }
}