using System;
using System.IO;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
    public interface CmsProcessable
    {
		/// <summary>
		/// Generic routine to copy out the data we want processed.
		/// </summary>
		/// <remarks>
		/// This routine may be called multiple times.
		/// </remarks>
        Task Write(Stream outStream);

        object GetContent();
    }
}
