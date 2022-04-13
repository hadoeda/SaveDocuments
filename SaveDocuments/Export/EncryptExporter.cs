using SaveDocuments.Document;
using SaveDocuments.Encrypt;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортёр документов в директорию, с шифрованием.
  /// </summary>
  internal class EncryptExporter : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортёр документов в директорию.
    /// </summary>
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для шифрования.
    /// </summary>
    private readonly EncryptProvider provider;

    #endregion

    #region IDocumentExporter

    public void Export(IDocument document, string path)
    {
      this.exporter.Export(document, path);
      Console.WriteLine();
      this.provider.Encript(path);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер документов.</param>
    public EncryptExporter(IDocumentExporter exporter)
    {
      if (exporter == null)
        throw new ArgumentNullException(nameof(exporter));

      this.exporter = exporter;
      this.provider = new EncryptProvider();
    }

    #endregion
  }
}
