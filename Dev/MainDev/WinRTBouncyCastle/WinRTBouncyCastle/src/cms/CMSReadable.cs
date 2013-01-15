using System;
using System.IO;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Cms
{
	internal interface CmsReadable
	{
		Task<Stream> GetInputStream();
	}
}
