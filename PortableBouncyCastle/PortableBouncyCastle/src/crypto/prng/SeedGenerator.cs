using System;
using System.Threading;
using Tiko;

namespace Org.BouncyCastle.Crypto.Prng
{
    /**
     * A thread based seed generator - one source of randomness.
     * <p>
     * Based on an idea from Marcus Lippert.
     * </p>
     */
    public abstract class SeedGenerator
    {
#if NETCF_1_0
		// No volatile keyword, but all fields implicitly volatile anyway
		private int		counter = 0;
		private bool	stop = false;
#else
        private volatile int counter = 0;
        private volatile bool stop = false;
#endif

        private void Run(object ignored)
        {
            while (!this.stop)
            {
                this.counter++;
            }
        }

        public abstract byte[] GenerateSeed(
			int numBytes,
			bool fast);

		public static SeedGenerator Create() {
			return TikoContainer.Resolve<SeedGenerator>();
		}

        /**
         * Generate seed bytes. Set fast to false for best quality.
         * <p>
         * If fast is set to true, the code should be round about 8 times faster when
         * generating a long sequence of random bytes. 20 bytes of random values using
         * the fast mode take less than half a second on a Nokia e70. If fast is set to false,
         * it takes round about 2500 ms.
         * </p>
         * @param numBytes the number of bytes to generate
         * @param fast true if fast mode should be used
         */
    }
}
