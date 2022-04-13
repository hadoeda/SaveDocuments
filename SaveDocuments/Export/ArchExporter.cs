using SaveDocuments.Archiver;
using SaveDocuments.Document;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортёр документа в директорию, с архивацией.
  /// </summary>
  internal class ArchExporter : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортер документов в директорию.
    /// </summary>
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для архивирования
    /// </summary>
    private readonly ArchProvider provider;

    #endregion

    #region IDocumentExporter

    public void Export(IDocument document, string path)
    {
      this.exporter.Export(document, path);
      Console.WriteLine();
      this.provider.Arch(path, document.Name);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер документов.</param>
    public ArchExporter(IDocumentExporter exporter)
    {
      if (exporter == null)
        throw new ArgumentNullException(nameof(exporter));

      this.exporter = exporter;
      this.provider = new ArchProvider();
    }

    #endregion
  }
}
