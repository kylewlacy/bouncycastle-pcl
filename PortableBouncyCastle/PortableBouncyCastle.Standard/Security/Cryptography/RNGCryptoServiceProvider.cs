using Tiko;
using InternalRNGCSP = System.Security.Cryptography.RNGCryptoServiceProvider;
using AbstractRNGCSP = Org.BouncyCastle.Portable.Security.Cryptography.RNGCryptoServiceProvider;

namespace Org.BouncyCastle.Standard.Security.Cryptography
{
	[Resolves(typeof(AbstractRNGCSP))]
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

