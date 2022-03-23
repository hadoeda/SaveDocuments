using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Encrypt
{
  internal class EncryptProvider
  {
    public void Encript(string path)
    {
      Console.WriteLine("Файлы в папке {0} зашифрованы", path);
    }

    public void Decript(string path)
    {
      Console.WriteLine("Файлы в папке {0} расшифрованы", path);
    }
  }
}
