Portable Bouncy Castle
======================
This is a port of the Bouncy Castle library for use with Portable Class Libraries. It is based off of the [WinRT port of Bouncy Castle by alazan](https://w8bouncycastle.codeplex.com).

Notes
=====
- In order to remain portable, some classes were abstracted, with dependencies injected. DI is handled by a [portable branch of TikoContainer](https://github.com/kylewlacy/TikoContainer), and it is expected that you setup the dependencies before using anything.
  - For an example of how to properly handle DI, take a look at the [`PortableBouncyCastle.Standard` project](https://github.com/kylewlacy/bouncycastle-pcl/tree/master/PortableBouncyCastle/PortableBouncyCastle.Standard). This project can also be used directly when targeting anything compatible with the .NET 4.0 client profile
- The only source of entropy used for the `SecureRandom` generator comes from `DateTime.Now.Ticks`. This is an area in need of improvement.
