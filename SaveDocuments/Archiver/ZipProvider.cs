using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Archiver
{
  internal class ZipProvider
  {
    public void Zip(string path, string fileName)
    {
      Console.WriteLine("Файлы из папки {0} запакованы в zip архив с именем {1}", path, fileName);
    }

    public void UnZip(string path, string fileName)
    {
      Console.WriteLine("Файлы из zip архива {0} распакованы в папку {1}", fileName, path);
    }
  }
}
