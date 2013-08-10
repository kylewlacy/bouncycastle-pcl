using System;

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Parameters;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
	internal interface CmsSecureReadable
	{
		AlgorithmIdentifier Algorithm { get; }
		object CryptoObject { get; }
		Task<CmsReadable> GetReadable(KeyParameter key);
	}
}
