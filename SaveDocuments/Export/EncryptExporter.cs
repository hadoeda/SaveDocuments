using SaveDocuments.Document;
using SaveDocuments.Encrypt;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортер с шифрованием документов в директорию.
  /// </summary>
  internal class EncryptExporter : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортер документов в директорию.
    /// </summary>
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для шифрования.
    /// </summary>
    private readonly EncryptProvider provider;

    #endregion

    #region IDocumentExporter

    public string Path => exporter.Path;

    public void Export(IDocument document)
    {
      this.exporter.Export(document);
      Console.WriteLine();
      this.provider.Encript(this.Path);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер документов.</param>
    public EncryptExporter(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
      this.provider = new EncryptProvider();
    }

    #endregion
  }
}
