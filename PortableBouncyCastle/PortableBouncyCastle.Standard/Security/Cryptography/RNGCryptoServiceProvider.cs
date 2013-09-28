using InternalRNGCSP = System.Security.Cryptography.RNGCryptoServiceProvider;
using AbstractRNGCSP = Org.BouncyCastle.Portable.Security.Cryptography.RNGCryptoServiceProvider;

namespace Org.BouncyCastle.Portable.Standard.Security.Cryptography
{
	public class RNGCryptoServiceProvider : AbstractRNGCSP
	{
		protected InternalRNGCSP InternalRNGCSP;

		protected override void Initialize ()
		{
			InternalRNGCSP = new InternalRNGCSP ();
		}

		public override void GetBytes (byte[] data)
		{
			InternalRNGCSP.GetBytes (data);
		}
	}
}

