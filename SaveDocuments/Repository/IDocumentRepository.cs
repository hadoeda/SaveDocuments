using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Repository
{
  /// <summary>
  /// Интерфейс репозиторий документов.
  /// </summary>
  internal interface IDocumentRepository
  {
    /// <summary>
    /// Получить документ из репозитория.
    /// </summary>
    /// <param name="id">Идентификатор репозитория.</param>
    /// <returns>Документ.</returns>
    IDocument Get(int id);

    /// <summary>
    /// Сохранить документ в репозиторий.
    /// </summary>
    /// <param name="document">Документ.</param>
    void Save(IDocument document);
  }
}
