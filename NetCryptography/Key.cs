using System;
using System.Security.Cryptography;

namespace NetCryptography
{
    class Key
    {
        private byte[] _key;

        public int Lenght 
        { 
            get { return _key.Length; }
        }

        public Key()
        {
        }

        public Key(int lenght)
        {
            Generete(lenght);
        }

        public Key(string line)
        {
            SetKey(line);
        }

        public Key(byte[] masKey)
        {
            SetKey(masKey);
        }

        public byte[] GetByteKey()
        {
            return _key;
        }

        public void SetKey(string line)
        {
            line = (line.Replace("-", "")).Replace(" ", "");
            _key = HexStringToByte(line);
        }

        public void SetKey(byte[] masKey)
        {
            _key = masKey;
        }

        public string GetStringKey()
        {
            return BitConverter.ToString(_key).Replace("-", string.Empty);
        }

        public string[] GetMasStringKey(int lenghtKeyBlock = 4, int numberBlocksInLine = 8)
        {            
            string keyString = GetStringKey();

            int showKeyLenght = lenghtKeyBlock * numberBlocksInLine;
            int countLine = (int) Math.Ceiling((double)keyString.Length / showKeyLenght);
            string[] keyStrings = new string[countLine];

            for (int i = 0; i < countLine; i++)
            {
                string keySubString = keyString.Substring(showKeyLenght*i,
                    (keyString.Length < showKeyLenght*(i + 1)) ? (keyString.Length - showKeyLenght*i) : showKeyLenght);

                keyStrings[i] = keySubString.Substring(0, lenghtKeyBlock);
                for (int j = 1; j*lenghtKeyBlock < keySubString.Length; j++)
                    keyStrings[i] += @" - " +
                                     keySubString.Substring(j*lenghtKeyBlock,
                                         (keySubString.Length < lenghtKeyBlock*(j + 1))
                                             ? (keySubString.Length - lenghtKeyBlock*j)
                                             : lenghtKeyBlock);
            }
            return keyStrings;
        }

        static public string[] GetMasStringKey(string keyString, int lenghtKeyBlock = 4, int numberBlocksInLine = 8)
        {
            int showKeyLenght = lenghtKeyBlock * numberBlocksInLine;
            int countLine = (int)Math.Ceiling((double)keyString.Length / showKeyLenght);
            string[] keyStrings = new string[countLine];

            for (int i = 0; i < countLine; i++)
            {
                string keySubString = keyString.Substring(showKeyLenght * i,
                    (keyString.Length < showKeyLenght * (i + 1)) ? (keyString.Length - showKeyLenght * i) : showKeyLenght);

                keyStrings[i] = keySubString.Substring(0, lenghtKeyBlock);
                for (int j = 1; j * lenghtKeyBlock < keySubString.Length; j++)
                    keyStrings[i] += @" - " +
                                     keySubString.Substring(j * lenghtKeyBlock,
                                         (keySubString.Length < lenghtKeyBlock * (j + 1))
                                             ? (keySubString.Length - lenghtKeyBlock * j)
                                             : lenghtKeyBlock);
            }
            return keyStrings;
        }

        public void Generete(int lenght)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            _key = new byte[lenght];
            rng.GetNonZeroBytes(_key);
        }

        static public string Генерувати(int розмірКлюча)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] randomKey = new Byte[розмірКлюча];//ключ в байтах

            rng.GetNonZeroBytes(randomKey); //The array is now filled with cryptographically strong random bytes.

            return BitConverter.ToString(randomKey).Replace("-", string.Empty);//(пароль записывается в 16-м виде, видаливши "-")
        }

        static public byte[] HexStringToByte(string line)
        {
            byte[] rez = null;
           // if ((line.Length / 2) % 2 == 0)//якщо строка має парну кількість елементів
            {
                rez = new byte[line.Length / 2];

                for (int i = 0, j = 0; i < rez.Length; i++, j += 2)//конвертування hex строки в байт
                    rez[i] = byte.Parse(line.Substring(j, 2), System.Globalization.NumberStyles.HexNumber);//конвертування по два елементи строки
            }
            return rez;
        }
    }
}
