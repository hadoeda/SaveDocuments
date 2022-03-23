using SaveDocuments.Document;
using SaveDocuments.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Repository
{
  /// <summary>
  /// Репозиторий в файловой системе
  /// </summary>
  internal class DirectoryDocumentRepositor : IDocumentRepository
  {
    /// <summary>
    /// Алгоритм экспорта документа
    /// </summary>
    private readonly IDocumentExporter exporter;

    public IDocument Get(int id)
    {
      Console.WriteLine("Get document by id {0}", id);
      return SimpleDocument.Empty(id);
    }

    public void Save(IDocument document)
    {
      this.exporter.Export(document);
    }

    public DirectoryDocumentRepositor(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
    }
  }
}
