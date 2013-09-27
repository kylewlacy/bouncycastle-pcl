using System;

namespace Org.BouncyCastle.Portable.IO
{
	public abstract class FileInfo
	{
		public abstract string FullName { get; }
		public abstract string Name { get; }
		public abstract long Length { get; }
		public abstract DateTime LastWriteTime { get; set; }

		public abstract FileStream OpenRead ();
	}
}

