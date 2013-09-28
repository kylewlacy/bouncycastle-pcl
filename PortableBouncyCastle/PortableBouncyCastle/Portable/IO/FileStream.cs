using System;
using System.IO;
using Tiko;

namespace Org.BouncyCastle.Portable.IO
{
	public abstract class FileStream : Stream
	{
		protected abstract void Initialize (string path, FileMode mode, FileAccess access, FileShare share, int bufferSize);

		public static FileStream Create (string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
		{
			var fileStream = TikoContainer.Resolve<FileStream> ();
			fileStream.Initialize (path, mode, access, share, bufferSize);
			return fileStream;
		}
	}
}
