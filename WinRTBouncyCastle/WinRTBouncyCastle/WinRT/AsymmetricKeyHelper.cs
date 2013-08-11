//---------------------------------------------------------------------------
// <copyright file="AsymmetricKeyHelper.cs" company="sandorfr">
//
//     Copyright (c) 2013 Cyprien Autexier.
//
//     Licensed under the The MIT License (MIT) (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//
//         https://w8bouncycastle.codeplex.com/license
//
//     Permission is hereby granted, free of charge, to any person  
//     obtaining a copy of this software and associated documentation  
//     files (the "Software"), to deal in the Software without restriction, 
//     including without limitation the rights to use, copy, modify, merge, 
//     publish, distribute, sublicense, and/or sell copies of the Software, 
//     and to permit persons to whom the Software is furnished to do so, 
//     subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be 
//     included in all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
//     MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
//     IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
//     CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
//     TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
//     SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//     
// </copyright>
//---------------------------------------------------------------------------

namespace Org.BouncyCastle.WinRT
{
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.X509;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;

    /// <summary>
    /// Provides a set of extension methods to help use asymetric key extracted from a X509 certificate along with native cryptographic WinRT Apis
    /// </summary>
    public static class BouncyCastleKeyHelper
    {
        // <summary>
        /// Converts Private Key contained in an <see cref="Pkcs12Store"/> to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="keyEntry">Source certificate</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import public key</param>
        /// <returns>Created CryptographicKey containing public key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPrivateKey(this Pkcs12Store store, string algName)
        {
            return ToCryptographicPrivateKey(store.GetKey("key"), algName);
        }

        /// <summary>
        /// Converts a <see cref="AsymmetricKeyEntry"/> that must contain Private Key informations to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="keyEntry">Source AsymmetricKeyEntry</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import private key</param>
        /// <returns>Created CryptographicKey containing private key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPrivateKey(this AsymmetricKeyEntry keyEntry, string algName)
        {
            return ToCryptographicPrivateKey(keyEntry.Key, algName);
        }

        /// <summary>
        /// Converts <see cref="AsymmetricKeyEntry"/> that must contain Private Key informations to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="key">Source AsymmetricKeyParameter</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import private key</param>
        /// <returns>Created CryptographicKey containing private key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPrivateKey(this AsymmetricKeyParameter key, string algName)
        {
            var pkey = PrivateKeyInfoFactory.CreatePrivateKeyInfo(key);

            var pkcs8 = pkey.GetDerEncoded();

            var alg = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(algName);

            return alg.ImportKeyPair(CryptographicBuffer.CreateFromByteArray(pkcs8), Windows.Security.Cryptography.Core.CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo);
        }

        /// <summary>
        /// Converts Public Key contained in an <see cref="X509Certificate"/> to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="keyEntry">Source certificate</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import public key</param>
        /// <returns>Created CryptographicKey containing public key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPublicKey(this X509Certificate certificate, string algName)
        {
            return ToCryptographicPrivateKey(certificate.GetPublicKey(), algName);
        }

        /// <summary>
        /// Converts Public Key contained in an <see cref="AsymmetricKeyEntry"/> to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="keyEntry">Source AsymmetricKeyEntry</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import public key</param>
        /// <returns>Created CryptographicKey containing public key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPublicKey(this AsymmetricKeyEntry keyEntry, string algName)
        {
            return ToCryptographicPublicKey(keyEntry.Key, algName);
        }

        /// <summary>
        /// Converts Public Key contained in an <see cref="AsymmetricKeyEntry"/> to <see cref="CryptographicKey"/>
        /// </summary>
        /// <param name="key">Source AsymmetricKeyParameter</param>
        /// <param name="algName">Asymmetric Algorithm which will be used to Import public key</param>
        /// <returns>Created CryptographicKey containing public key to be used along with <see cref="CryptographicEngine"/></returns>
        public static CryptographicKey ToCryptographicPublicKey(this AsymmetricKeyParameter key, string algName)
        {
            var subject = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(key);

            var pkcs8 = subject.GetDerEncoded();

            var alg = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(algName);

            return alg.ImportPublicKey(CryptographicBuffer.CreateFromByteArray(pkcs8), Windows.Security.Cryptography.Core.CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo);
        }
    }
}
