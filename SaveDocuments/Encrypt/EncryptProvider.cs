using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Encrypt
{
  /// <summary>
  /// Провайдер шифрования.
  /// </summary>
  internal class EncryptProvider
  {
    #region Методы

    /// <summary>
    /// Шифрует файлы в указанной директории.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    public void Encript(string path)
    {
      Console.WriteLine("Файлы в папке {0} зашифрованы", path);
    }

    /// <summary>
    /// Расшифровывает файлы в укзанной директории.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    public void Decript(string path)
    {
      Console.WriteLine("Файлы в папке {0} расшифрованы", path);
    }

    #endregion
  }
}
