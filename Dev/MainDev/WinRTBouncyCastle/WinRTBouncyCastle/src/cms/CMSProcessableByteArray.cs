using System;
using System.IO;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
	/**
	* a holding class for a byte array of data to be processed.
	*/
	public class CmsProcessableByteArray
		: CmsProcessable, CmsReadable
	{
		private readonly byte[] bytes;

		public CmsProcessableByteArray(
			byte[] bytes)
		{
			this.bytes = bytes;
		}

		public async Task<Stream> GetInputStream()
		{
			return new MemoryStream(bytes, false);
		}

		public async virtual Task Write(Stream zOut)
		{
			zOut.Write(bytes, 0, bytes.Length);
		}

		/// <returns>A clone of the byte array</returns>
		public virtual object GetContent()
		{
			return bytes.Clone();
		}
	}
}
