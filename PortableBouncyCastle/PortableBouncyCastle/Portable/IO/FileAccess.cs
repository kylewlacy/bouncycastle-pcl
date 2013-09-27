using System;

namespace Org.BouncyCastle.Portable.IO
{
	[Flags]
	public enum FileAccess
	{
		Read      = 1,
		Write     = 2,
		ReadWrite = 3
	}
}

