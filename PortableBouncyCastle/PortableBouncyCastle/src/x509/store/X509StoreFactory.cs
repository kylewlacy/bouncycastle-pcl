using System;
using System.Collections;
using System.Globalization;

namespace Org.BouncyCastle.X509.Store
{
	public sealed class X509StoreFactory
	{
		private X509StoreFactory()
		{
		}

		public static IX509Store Create(
			string					type,
			IX509StoreParameters	parameters)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			string[] parts = type.ToUpperInvariant().Split('/');

			if (parts.Length < 2)
				throw new ArgumentException("type");

			if (parts[1] != "COLLECTION")
				throw new NoSuchStoreException("X.509 store type '" + type + "' not available.");

			X509CollectionStoreParameters p = (X509CollectionStoreParameters) parameters;
			ICollection coll = p.GetCollection();

			switch (parts[0])
			{
				case "ATTRIBUTECERTIFICATE":
					checkCorrectType<IX509AttributeCertificate>(coll);
					break;
				case "CERTIFICATE":
					checkCorrectType<X509Certificate>(coll);
					break;
				case "CERTIFICATEPAIR":
					checkCorrectType<X509CertificatePair>(coll);
					break;
				case "CRL":
					checkCorrectType<X509Crl>(coll);
					break;
				default:
					throw new NoSuchStoreException("X.509 store type '" + type + "' not available.");
			}

			return new X509CollectionStore(coll);
		}

		private static void checkCorrectType<T>(ICollection coll)
		{
			foreach (object o in coll)
			{
				if (!(o is T))
					throw new InvalidCastException("Can't cast object to type: " + typeof(T).FullName);
			}
		}
	}
}
