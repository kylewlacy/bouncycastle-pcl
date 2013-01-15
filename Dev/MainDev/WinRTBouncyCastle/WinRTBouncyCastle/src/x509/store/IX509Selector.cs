using System;

namespace Org.BouncyCastle.X509.Store
{
	public interface IX509Selector
	{
        object Clone();

        bool Match(object obj);
	}
}
