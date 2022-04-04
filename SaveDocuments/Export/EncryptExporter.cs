using SaveDocuments.Document;
using SaveDocuments.Encrypt;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортёр документов в директорию, с шифрованием.
  /// </summary>
  internal class EncryptExporter : DirectoryExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортёр документов в директорию.
    /// </summary>
    private readonly DirectoryExporter exporter;

    /// <summary>
    /// Провайдер для шифрования.
    /// </summary>
    private readonly EncryptProvider provider;

    #endregion

    #region IDocumentExporter

    public override void Export(IDocument document)
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
    public EncryptExporter(DirectoryExporter exporter) : base(exporter.Path)
    {
      if (exporter == null)
        throw new ArgumentNullException(nameof(exporter));

      this.exporter = exporter;
      this.provider = new EncryptProvider();
    }

    #endregion
  }
}
