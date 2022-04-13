using SaveDocuments.Document;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортёр документа.
  /// </summary>
  internal interface IDocumentExporter
  {
    /// <summary>
    /// Экспортировать документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    /// <param name="path">Путь экспорта.</param>
    void Export(IDocument document, string path);
  }
}
