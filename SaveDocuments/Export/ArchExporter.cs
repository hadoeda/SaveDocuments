using SaveDocuments.Archiver;
using SaveDocuments.Document;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортёр документа в директорию, с архивацией.
  /// </summary>
  internal class ArchExporter : DirectoryExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортер документов в директорию.
    /// </summary>
    private readonly DirectoryExporter exporter;

    /// <summary>
    /// Провайдер для архивирования
    /// </summary>
    private readonly ArchProvider provider;

    #endregion

    #region IDocumentExporter

    public override void Export(IDocument document)
    {
      this.exporter.Export(document);
      Console.WriteLine();
      this.provider.Arch(this.Path, document.Name);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер документов.</param>
    public ArchExporter(DirectoryExporter exporter) : base(exporter.Path)
    {
      if (exporter == null)
        throw new ArgumentNullException(nameof(exporter));

      this.exporter = exporter;
      this.provider = new ArchProvider();
    }

    #endregion
  }
}
