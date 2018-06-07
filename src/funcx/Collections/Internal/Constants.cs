using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class Constants
    {
        /// <summary>
        /// The maximum number of entries to before changing the <see cref="ArrayMap"/> implementation to a <see cref="HashMap"/>.
        /// </summary>
        public const int HASH_TABLE_THRESHOLD = 16;

        public const int CHUNK_SIZE = 32;
    }
}
