using System;

namespace SaveDocuments.Encrypt
{
  /// <summary>
  /// Провайдер шифрования.
  /// </summary>
  internal class EncryptProvider
  {
    #region Методы

    /// <summary>
    /// Зашифровать файлы в директории.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    public void Encript(string path)
    {
      Console.WriteLine("Файлы в папке {0} зашифрованы", path);
    }

    /// <summary>
    /// Расшифровать файлы в директории.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    public void Decript(string path)
    {
      Console.WriteLine("Файлы в папке {0} расшифрованы", path);
    }

    #endregion
  }
}
