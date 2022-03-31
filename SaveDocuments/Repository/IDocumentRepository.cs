﻿using SaveDocuments.Document;

namespace SaveDocuments.Repository
{
  /// <summary>
  /// Репозиторий документов.
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
