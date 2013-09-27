using System;

namespace Org.BouncyCastle.Portable.Security.Cryptography
{
	public abstract class RNGCryptoServiceProvider
	{
		public abstract void GetBytes (byte[] data);

		public static RNGCryptoServiceProvider Create ()
		{
			throw new NotImplementedException ();
		}
	}
}

