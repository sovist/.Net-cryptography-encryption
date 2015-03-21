using System.IO;

namespace SPS
{
    class FileSizeInfo
    {
        private readonly long _fileLenght;
        public string ShortForm 
        {
            get
            {
                double size = (double)_fileLenght / 1024;
                string p = " Kb";

                if (size > 1024)
                {
                    size /= 1024;
                    p = " Mb";
                }

                if (size > 1024)
                {
                    size /= 1024;
                     p = " Gb";
                }
                return "Розмір - " + size.ToString("f2") + p + " (" + _fileLenght.ToString("C0").Replace("р.", string.Empty) + " байт)";
            }
        }

        public FileSizeInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            _fileLenght = fileInfo.Length;
        }
    }
}
