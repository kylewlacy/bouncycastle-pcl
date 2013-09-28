using System;
using Tiko;
using InternalFileStream = System.IO.FileStream;
using AbstractFileStream = Org.BouncyCastle.Portable.IO.FileStream;

namespace Org.BouncyCastle.Standard.IO
{
	[Resolves(typeof(AbstractFileStream))]
	public class FileStream : AbstractFileStream
	{
		protected InternalFileStream InternalFileStream;

		public override bool CanRead {
			get { return InternalFileStream.CanRead; }
		}

		public override bool CanWrite {
			get { return InternalFileStream.CanWrite; }
		}

		public override bool CanSeek {
			get { return InternalFileStream.CanSeek; }
		}

		public override bool CanTimeout {
			get { return InternalFileStream.CanTimeout; }
		}

		public override long Length {
			get { return InternalFileStream.Length; }
		}

		public override long Position {
			get { return InternalFileStream.Position; }
			set { InternalFileStream.Position = value; }
		}

		public override int ReadTimeout {
			get { return InternalFileStream.ReadTimeout; }
			set { InternalFileStream.ReadTimeout = value; }
		}

		public override int WriteTimeout {
			get { return InternalFileStream.WriteTimeout; }
			set { InternalFileStream.WriteTimeout = value; }
		}

		public FileStream ()
		{

		}

		protected FileStream (InternalFileStream fileStream)
		{
			InternalFileStream = fileStream;
		}

		public override int Read (byte[] buffer, int offset, int count)
		{
			return InternalFileStream.Read (buffer, offset, count);
		}

		public override void Write (byte[] buffer, int offset, int count)
		{
			InternalFileStream.Write (buffer, offset, count);
		}

		public override void Flush ()
		{
			InternalFileStream.Flush ();
		}

		public override IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return InternalFileStream.BeginRead (buffer, offset, count, callback, state);
		}

		public override int EndRead (IAsyncResult asyncResult)
		{
			return InternalFileStream.EndRead (asyncResult);
		}

		public override IAsyncResult BeginWrite (byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return InternalFileStream.BeginWrite (buffer, offset, count, callback, state);
		}

		public override void EndWrite (IAsyncResult asyncResult)
		{
			InternalFileStream.EndWrite (asyncResult);
		}

		public override int ReadByte ()
		{
			return InternalFileStream.ReadByte ();
		}

		public override void WriteByte (byte value)
		{
			InternalFileStream.WriteByte (value);
		}

		public override long Seek (long offset, System.IO.SeekOrigin origin)
		{
			return InternalFileStream.Seek (offset, origin);
		}

		public override void SetLength (long value)
		{
			InternalFileStream.SetLength (value);
		}

		public override System.Runtime.Remoting.ObjRef CreateObjRef (Type requestedType)
		{
			return InternalFileStream.CreateObjRef (requestedType);
		}

		public override void Close ()
		{
			InternalFileStream.Close ();
		}

		protected override void Dispose (bool disposing)
		{
			InternalFileStream.Dispose ();
		}

		public override object InitializeLifetimeService ()
		{
			return InternalFileStream.InitializeLifetimeService ();
		}

		protected static System.IO.FileMode ToInternalFileMode (Org.BouncyCastle.Portable.IO.FileMode fileMode)
		{
			return (System.IO.FileMode)((int)fileMode);
		}

		protected static System.IO.FileAccess ToInternalFileAccess (Org.BouncyCastle.Portable.IO.FileAccess fileAccess)
		{
			return (System.IO.FileAccess)((int)fileAccess);
		}

		protected static System.IO.FileShare ToInternalFileShare (Org.BouncyCastle.Portable.IO.FileShare fileShare)
		{
			return (System.IO.FileShare)((int)fileShare);
		}

		protected override void Initialize (string path, Org.BouncyCastle.Portable.IO.FileMode mode, Org.BouncyCastle.Portable.IO.FileAccess access, Org.BouncyCastle.Portable.IO.FileShare share, int bufferSize)
		{
			InternalFileStream = new InternalFileStream (path, ToInternalFileMode (mode), ToInternalFileAccess (access), ToInternalFileShare (share), bufferSize);
		}

		public static FileStream FromSystemFileStream (InternalFileStream fileStream)
		{
			return new FileStream (fileStream);
		}
	}
}

