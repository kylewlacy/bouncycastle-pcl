using System;
using System.IO;

namespace Org.BouncyCastle.Portable.IO
{
	public abstract class FileStream : Stream
	{
		public static FileStream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize) {
			throw new NotImplementedException ();
		}
	}
}
