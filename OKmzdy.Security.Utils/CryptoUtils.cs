using System;
using System.Text;
using System.Runtime.InteropServices;

namespace OKmzdy.Security.Utils
{
    public static class CryptoUtils
    {
		#if WINDOWS_API        

		const string MASTER_PHRASE = "ABCDEFGHIJ";

        const int ENCRYPT_BLOCK_SIZE = 8;
        const int MAX_PASSWORDLEN = 26;
        const int MAX_PSBUFFERLEN = MAX_PASSWORDLEN + ENCRYPT_BLOCK_SIZE;

        static Encoding encFrom = Encoding.Default;
        static Encoding encTo = Encoding.Default;

        const int ALG_CLASS_HASH = (4 << 13);
        const int ALG_TYPE_ANY = 0;
        const int ALG_SID_MD5 = 3;
        const int ALG_CLASS_DATA_ENCRYPT = (3 << 13);
        const int ALG_TYPE_BLOCK = (3 << 9);
        const int ALG_SID_RC2 = 2;

        const int CALG_MD5 = (ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_MD5);
        const int CALG_RC2 = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_RC2);

        const int ERROR_SUCCESS = 0;
        const int ENCRYPT_ALGORITHM = CALG_RC2;



        private static class CryptoApiHelper
        {
            const string CryptDll = "advapi32.dll";
            const string KernelDll = "kernel32.dll";

            const int PROV_RSA_FULL = 1;
            const string MS_DEF_PROV = "Microsoft Base Cryptographic Provider v1.0";

            const Int64 NTE_BAD_KEYSET = (0x80090016L);
            const uint CRYPT_NEWKEYSET = (0x00000008);


            [DllImport(KernelDll)]
            private static extern uint GetLastError();
            [DllImport(CryptDll)]
            private static extern bool CryptAcquireContext(ref IntPtr phProv, string pszContainer, string pszProvider, uint dwProvType, uint dwFlags);
            [DllImport(CryptDll)]
            private static extern bool CryptDestroyKey(IntPtr hKey);
            [DllImport(CryptDll)]
            private static extern bool CryptCreateHash(IntPtr hProv, uint Algid, IntPtr hKey, uint dwFlags, ref IntPtr phHash);
            [DllImport(CryptDll)]
            private static extern bool CryptHashData(IntPtr hHash, byte[] pbData, uint dwDataLen, uint dwFlags);
            [DllImport(CryptDll)]
            private static extern bool CryptDestroyHash(IntPtr hHash);
            [DllImport(CryptDll)]
            private static extern bool CryptDeriveKey(IntPtr hProv, uint Algid, IntPtr hBaseData, uint dwFlags, ref IntPtr phKey);
            [DllImport(CryptDll)]
            public static extern bool CryptEncrypt(IntPtr hKey, IntPtr hHash, bool Final, uint dwFlags, byte[] pbData, ref uint pdwDataLen, uint dwBufLen);
            [DllImport(CryptDll)]
            public static extern bool CryptDecrypt(IntPtr hKey, IntPtr hHash, bool Final, uint dwFlags, byte[] pbData, ref uint pdwDataLen);

            public static uint AcquireContext(string pszContainer, ref IntPtr hContext)
            {
                uint dwErrCode = 0;

                if (CryptAcquireContext(ref hContext, pszContainer, MS_DEF_PROV, PROV_RSA_FULL, 0))
                    dwErrCode = ERROR_SUCCESS;
                else if ((dwErrCode = GetLastError()) == NTE_BAD_KEYSET)
                {
                    if (CryptAcquireContext(ref hContext, pszContainer, MS_DEF_PROV, PROV_RSA_FULL, CRYPT_NEWKEYSET))
                        dwErrCode = ERROR_SUCCESS;
                    else
                        dwErrCode = GetLastError();
                }
                return dwErrCode;
            }

            public static uint GenerateKey(uint algID, string pszPassword, ref IntPtr hKey, IntPtr hContext)
            {
                uint dwErrCode;

                if (hKey != IntPtr.Zero)
                    CryptDestroyKey(hKey);
                hKey = IntPtr.Zero;

                IntPtr hHash = IntPtr.Zero;

                if (!CryptCreateHash(hContext, CALG_MD5, IntPtr.Zero, 0, ref hHash))
                {
                    dwErrCode = GetLastError();
                    return dwErrCode;
                }

                byte[] pbKeyData = encFrom.GetBytes(pszPassword);
                uint nDataLen = Convert.ToUInt32(pszPassword.Length);
                if (!CryptHashData(hHash, pbKeyData, nDataLen, 0))
                {
                    dwErrCode = GetLastError();
                    CryptDestroyHash(hHash);
                    return dwErrCode;
                }

                if (!CryptDeriveKey(hContext, algID, hHash, 0, ref hKey))
                {
                    dwErrCode = GetLastError();
                    CryptDestroyHash(hHash);
                    return dwErrCode;
                }

                CryptDestroyHash(hHash);
                return 0;
            }
        }


        private static byte[] TextString2BinString(string strText)
        {
            int dataLen = Math.Min(strText.Length / 2, MAX_PSBUFFERLEN);

            byte[] byteText = new byte[MAX_PSBUFFERLEN];
            for (int i = 0, ii = 0; i < MAX_PSBUFFERLEN; i++, ii += 2)
            {
                byteText[i] = 0;
                if (i < dataLen)
                {
                    string hexText = strText.Substring(ii, 2);
                    byteText[i] = Convert.ToByte(hexText, 16);
                }
            }
            return byteText;
        }

        private static string BinString2TextString(byte[] byteText, int dataLen)
        {
            string strText = "";
            for (int i = 0; i < dataLen; i++)
            {
                strText += Convert.ToString(byteText[i], 16);
            }
            return strText;
        }


        private static byte[] TextString2ByteArray(string strText)
        {
            byte[] byteText = new byte[MAX_PSBUFFERLEN];

            int dataLen = Math.Min(strText.Length, MAX_PASSWORDLEN);

            char[] charText = strText.ToCharArray();

            for (int i = 0; i < MAX_PASSWORDLEN; i++)
            {
                byteText[i] = 0;
                if (i < dataLen)
                {
                    byteText[i] = Convert.ToByte(charText[i]);
                }
            }
            return byteText;
        }

        public static string HashToPlainText(string hashTextPswd)
        {
            string decryptedPassword = "";

            byte[] encryptedBytes = TextString2BinString(hashTextPswd);

            try
            {
                uint dwErrCode = 0;
                IntPtr hContext = IntPtr.Zero;
                IntPtr hKey = IntPtr.Zero;

                if ((dwErrCode = CryptoApiHelper.AcquireContext("OKmzdy", ref hContext)) == ERROR_SUCCESS)
                {
                    if ((dwErrCode = CryptoApiHelper.GenerateKey(ENCRYPT_ALGORITHM, MASTER_PHRASE, ref hKey, hContext)) == ERROR_SUCCESS)
                    {
                        uint data_size = Convert.ToUInt32(Math.Min(hashTextPswd.Length / 2, MAX_PSBUFFERLEN));

                        if (CryptoApiHelper.CryptDecrypt(hKey, IntPtr.Zero, true, 0, encryptedBytes, ref data_size))
                        {
                            decryptedPassword = encFrom.GetString(encryptedBytes).Substring(0, (int)data_size);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("Exception loading file: {0}", ex.ToString()));
            }
            return decryptedPassword;
        }
        public static string PlainTextToHash(string plainTextPswd)
        {
            string encryptedPassword = "";

            byte[] decryptedBytes = TextString2ByteArray(plainTextPswd);

            try
            {
                uint dwErrCode = 0;
                IntPtr hContext = IntPtr.Zero;
                IntPtr hKey = IntPtr.Zero;

                if ((dwErrCode = CryptoApiHelper.AcquireContext("OKmzdy", ref hContext)) == ERROR_SUCCESS)
                {
                    if ((dwErrCode = CryptoApiHelper.GenerateKey(ENCRYPT_ALGORITHM, MASTER_PHRASE, ref hKey, hContext)) == ERROR_SUCCESS)
                    {
                        uint data_size = Convert.ToUInt32(plainTextPswd.Length);

                        if (CryptoApiHelper.CryptEncrypt(hKey, IntPtr.Zero, true, 0, decryptedBytes, ref data_size, MAX_PSBUFFERLEN))
                        {
                            encryptedPassword = BinString2TextString(decryptedBytes, (int)data_size).ToUpper();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("Exception loading file: {0}", ex.ToString()));
            }
            return encryptedPassword;
        }
		#else

        public static string HashToPlainText(string hashTextPswd)
        {
            string decryptedPassword = hashTextPswd;

            return decryptedPassword;
        }
        public static string PlainTextToHash(string plainTextPswd)
        {
            string encryptedPassword = plainTextPswd;

            return encryptedPassword;
        }
		#endif
    }
}
