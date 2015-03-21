using System;
using System.IO;

namespace NetCryptography
{
    class Entropy
    {
        public Int64[] BytesCount { get; private set; }
        public double Value { get; private set; }

        public Entropy(string fileName)
        {
            BytesCount = Calculate(fileName);
            Value = Calculate(fileName, BytesCount);
        }

        static public Int64[] Calculate(string file)
        {
            Int64[] masCountBytes = new Int64[256];
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                {
                    Int64 length = fileRead.BaseStream.Length;

                    while (fileRead.BaseStream.Position != length)
                    {
                        byte[] temp1 = fileRead.ReadBytes(1600000);

                        foreach (byte b in temp1)
                            masCountBytes[b]++;
                    }
                }
            }
            catch (IOException) { }

            return masCountBytes;
        }

        static public double Calculate(string file, Int64[] masBytes)
        {
            if (masBytes == null)
                masBytes = Calculate(file);

            Int64 length = 1;
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                    length = fileRead.BaseStream.Length;
            }
            catch (IOException) { }

            double entropi = 0;
            for (int i = 0; i < masBytes.Length; i++)
                if (masBytes[i] != 0)
                    entropi += -((double)masBytes[i] / length) * Math.Log((double)masBytes[i] / length, 2);

            return entropi;
        }

        static public Int64[] Calculate(string file, out double entropi)
        {
            Int64[] rez = Calculate(file);
            entropi = Calculate(file, rez);
            return rez;
        }
    }
}
