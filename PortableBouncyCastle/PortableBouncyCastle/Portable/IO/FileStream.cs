using System;
using System.IO;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Portable.IO
{
	public abstract class FileStream : Stream
	{
		public async static Task<FileStream> Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize) {
			throw new NotImplementedException ();
		}
	}
}
