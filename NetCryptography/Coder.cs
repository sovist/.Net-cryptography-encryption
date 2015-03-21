using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace NetCryptography
{
    class Coder: IDisposable
    {
        public delegate void DelegateUpdateProgres(int value);

        private FileStream _fileIn;
        private FileStream _fileOut;

        public Coder()
        {
        }

        public Coder(String inputFileName, String outputFileName, ICryptoTransform algorithmCryptoTransform,  DelegateUpdateProgres delegateUpdateProgres)
        {
            EncryptData(inputFileName, outputFileName, algorithmCryptoTransform, delegateUpdateProgres);
        }

        public void EncryptData(String inputFileName, String outputFileName, ICryptoTransform algorithmCryptoTransform, DelegateUpdateProgres delegateUpdateProgres)
        {
            _fileIn = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
            _fileOut = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);
            _fileOut.SetLength(0);

            byte[] bin = new byte[50000 * 32];
            long rdlen = 0;
            long totlen = _fileIn.Length;
            int len;

            CryptoStream encStream = new CryptoStream(_fileOut, algorithmCryptoTransform, CryptoStreamMode.Write);

            while (rdlen < totlen)
            {
                len = _fileIn.Read(bin, 0, bin.Length);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                delegateUpdateProgres((int)(((double)_fileIn.Position / totlen) * 98));
            }

            try
            {
                _fileIn.Close();
                encStream.Close();
            }
            catch (Exception)
            {
                _fileIn.Close();
                _fileOut.Close();
                MessageBox.Show(@"Невірний ключ або вектор ініціалізації");
            }
            delegateUpdateProgres(100);
        }

        public void Dispose()
        {
            if(_fileIn != null)
                _fileIn.Close();

            if(_fileOut != null )
                _fileOut.Close();
        }
    }
}
