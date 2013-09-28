using System;
using Tiko;

namespace Org.BouncyCastle.Portable.Security.Cryptography
{
	public abstract class RNGCryptoServiceProvider
	{
		public abstract void GetBytes (byte[] data);

		protected abstract void Initialize ();

		public static RNGCryptoServiceProvider Create ()
		{
			var cryptoServiceProvider = TikoContainer.Resolve<RNGCryptoServiceProvider> ();
			cryptoServiceProvider.Initialize ();
			return cryptoServiceProvider;
		}
	}
}

