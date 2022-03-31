using SaveDocuments.Document;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортер документа в хранилище.
  /// </summary>
  internal interface IDocumentExporter
  {
    /// <summary>
    /// Директория.
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Экспортировать документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    void Export(IDocument document);
  }
}
