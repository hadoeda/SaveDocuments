using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Archiver
{
  /// <summary>
  /// Провайдер архивирования.
  /// </summary>
  internal class ZipProvider
  {
    #region Методы
    
    /// <summary>
    /// Архивирует документы в указанной директории.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    /// <param name="fileName">Имя файла архива.</param>
    public void Zip(string path, string fileName)
    {
      Console.WriteLine("Файлы из папки {0} запакованы в zip архив с именем {1}", path, fileName);
    }

    /// <summary>
    /// Разархивирует указанный файл в указанную директорию.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    /// <param name="fileName">Имя файла архива.</param>
    public void UnZip(string path, string fileName)
    {
      Console.WriteLine("Файлы из zip архива {0} распакованы в папку {1}", fileName, path);
    }

    #endregion
  }
}
