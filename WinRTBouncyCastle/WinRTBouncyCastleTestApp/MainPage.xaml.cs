using Org.BouncyCastle.Crypto.Tls;
using System;
using System.IO;
using Windows.Networking.Sockets;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinRTBouncyCastleTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, ICertificateVerifyer
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var socket = new StreamSocket();
            await socket.ConnectAsync(new Windows.Networking.HostName("w138.scarbo.fr"), "64738", SocketProtectionLevel.PlainSocket);
            TlsProtocolHandler handler = new TlsProtocolHandler(socket.InputStream.AsStreamForRead(), socket.OutputStream.AsStreamForWrite());

            handler.Connect(this);

        }

        //private class tlsClient : TlsClient
        //{
        //    public void Init(TlsClientContext context)
        //    {
        //    }

        //    public CipherSuite[] GetCipherSuites()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public CompressionMethod[] GetCompressionMethods()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public System.Collections.IDictionary GetClientExtensions()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void NotifySessionID(byte[] sessionID)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void NotifySelectedCipherSuite(CipherSuite selectedCipherSuite)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void NotifySelectedCompressionMethod(CompressionMethod selectedCompressionMethod)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void NotifySecureRenegotiation(bool secureRenegotiation)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void ProcessServerExtensions(System.Collections.IDictionary serverExtensions)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public TlsKeyExchange GetKeyExchange()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public TlsAuthentication GetAuthentication()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public TlsCompression GetCompression()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public TlsCipher GetCipher()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public bool IsValid(Org.BouncyCastle.Asn1.X509.X509CertificateStructure[] certs)
        {
            return true;
        }
    }
}
