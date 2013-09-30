using System;
using Org.BouncyCastle.Crypto.Prng;
using Tiko;
using System.Threading;
using System.Threading.Tasks;

namespace Org.BouncyCastle.Standard.Crypto.Prng{
	    /**
     * A thread based seed generator - one source of randomness.
     * <p>
     * Based on an idea from Marcus Lippert.
     * </p>
     */
	[Resolves(typeof(SeedGenerator))]
	public class ThreadedSeedGenerator : SeedGenerator
	{
#if NETCF_1_0
		// No volatile keyword, but all fields implicitly volatile anyway
		private int     counter = 0;
		private bool    stop = false;
#else
		private volatile int counter = 0;
		private volatile bool stop = false;
#endif
			 
//		private void Run(object ignored)
		private void Run()
		{
	    	while (!this.stop)
			{
				this.counter++;
			}
		}

		public override byte[] GenerateSeed(
			int numBytes,
			bool fast)
			{
			this.counter = 0;
			this.stop = false;

			byte[] result = new byte[numBytes];
			int last = 0;
			int end = fast ? numBytes : numBytes * 8;

			Task.Run(new Action(Run));
//			ThreadPool.RunAsync(new WorkItemHandler(Run));

			for (int i = 0; i < end; i++)
			{
				while (this.counter == last)
				{
					try
					{
						SpinWait.SpinUntil(() => false, 1);
					}
					catch (Exception)
					{
						// ignore
					}
				}

				last = this.counter;

				if (fast)
				{
					result[i] = (byte)last;
				}
				else
				{
					int bytepos = i / 8;
					result[bytepos] = (byte)((result[bytepos] << 1) | (last & 1));
				}
			}

			this.stop = true;

			return result;
		}
	}
}

