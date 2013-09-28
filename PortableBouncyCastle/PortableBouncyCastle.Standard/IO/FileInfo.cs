using System;
using AbstractFileInfo = Org.BouncyCastle.Portable.IO.FileInfo;
using InternalFileInfo = System.IO.FileInfo;

namespace Org.BouncyCastle.Standard.IO
{
	public class FileInfo : AbstractFileInfo
	{
		public FileInfo ()
		{

		}

		protected FileInfo (InternalFileInfo fileInfo)
		{
			InternalFileInfo = fileInfo;
		}

		protected InternalFileInfo InternalFileInfo;

		public override string FullName {
			get { return InternalFileInfo.FullName; }
		}

		public override string Name {
			get { return InternalFileInfo.Name; }
		}

		public override long Length {
			get { return InternalFileInfo.Length; }
		}

		public override DateTime LastWriteTime {
			get { return InternalFileInfo.LastAccessTime; }
			set { InternalFileInfo.LastWriteTime = value; }
		}

		public override Org.BouncyCastle.Portable.IO.FileStream OpenRead ()
		{
			return FileStream.FromSystemFileStream (InternalFileInfo.OpenRead ());
		}

		public static FileInfo FromSystemFileInfo (InternalFileInfo fileInfo)
		{
			return new FileInfo (fileInfo);
		}
	}
}

