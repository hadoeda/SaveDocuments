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
  /// Репозиторий в файловой системе.
  /// </summary>
  internal class DirectoryDocumentRepositor : IDocumentRepository
  {
    #region Поля и свойства
    
    /// <summary>
    /// Алгоритм экспорта документа.
    /// </summary>
    private readonly IDocumentExporter exporter;

    #endregion

    #region IDocumentRepository
    
    public IDocument Get(int id)
    {
      Console.WriteLine("Get document by id {0}", id);
      return SimpleDocument.Empty(id);
    }

    public void Save(IDocument document)
    {
      this.exporter.Export(document);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер.</param>
    public DirectoryDocumentRepositor(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
    }

    #endregion
  }
}
