using System;
using System.IO;

using Org.BouncyCastle.Utilities.IO;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
	public class CmsProcessableInputStream
		: CmsProcessable, CmsReadable
	{
		private Stream input;
		private bool used = false;

		public CmsProcessableInputStream(
			Stream input)
		{
			this.input = input;
		}

		public async Task<Stream> GetInputStream()
		{
			CheckSingleUsage();

			return input;
		}

		public async Task Write(Stream output)
		{
			CheckSingleUsage();

			Streams.PipeAll(input, output);
			input.Dispose();
		}

		public object GetContent()
		{
			return GetInputStream();
		}

		private void CheckSingleUsage()
		{
			lock (this)
			{
				if (used)
					throw new InvalidOperationException("CmsProcessableInputStream can only be used once");

				used = true;
			}
		}
	}
}
