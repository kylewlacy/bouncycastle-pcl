using System;
using System.IO;
#warning winrtstreams to regular streams ;
using System.Runtime.InteropServices.WindowsRuntime;

using Org.BouncyCastle.Utilities.IO;
using Windows.Storage;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
	/**
	* a holding class for a file of data to be processed.
	*/
	public class CmsProcessableFile
		: CmsProcessable, CmsReadable
	{
		private const int DefaultBufSize = 32 * 1024;

        private readonly StorageFile _file;
		private readonly int		_bufSize;

#warning big change
		public CmsProcessableFile( StorageFile file)
			: this(file, DefaultBufSize)
		{
		}

		public CmsProcessableFile(
            StorageFile file,
			int			bufSize)
		{
			_file = file;
			_bufSize = bufSize;
		}

#warning move to async
		public async virtual Task<Stream> GetInputStream()
		{
            return (await _file.OpenAsync(FileAccessMode.Read)).AsStreamForRead(DefaultBufSize);
            //return new FileStream(
            //    _file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, _bufSize);
		}

#warning move to async
        public async virtual Task Write(
			Stream zOut)
		{
			Stream inStr = await GetInputStream();
			Streams.PipeAll(inStr, zOut);
			inStr.Dispose();
		}

		/// <returns>The file handle</returns>
		public virtual object GetContent()
		{
			return _file;
		}
	}
}
