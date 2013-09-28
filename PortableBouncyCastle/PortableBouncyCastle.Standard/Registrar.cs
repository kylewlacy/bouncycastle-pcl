using System;
using Tiko;

namespace Org.BouncyCastle.Portable.Standard
{
	public static class Registrar
	{
		public static void Register ()
		{
			TikoContainer.Register<Portable.Security.Cryptography.RNGCryptoServiceProvider, Standard.Security.Cryptography.RNGCryptoServiceProvider> ();
			TikoContainer.Register<Portable.IO.FileStream, Standard.IO.FileStream> ();
			TikoContainer.Register<Portable.IO.FileInfo, Standard.IO.FileInfo> ();
		}
	}
}

