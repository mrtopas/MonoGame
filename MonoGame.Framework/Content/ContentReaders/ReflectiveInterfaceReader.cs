using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class ReflectiveInterfaceReader : ContentTypeReader
    {
        public ReflectiveInterfaceReader(Type interfaceType)
            : base(interfaceType)
        {
        }

        protected internal override object Read(ContentReader input, object existingInstance)
        {
            var typeReaderIndex = input.Read7BitEncodedInt();
            var typeReader = input.TypeReaders[typeReaderIndex];

            if (typeReader == null) return null;

            return typeReader.Read(input, existingInstance);
        }
    }
}
