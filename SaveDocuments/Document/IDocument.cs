using System.Collections.Generic;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Документ.
  /// </summary>
  internal interface IDocument : IEnumerable<IDocument>
  {
    /// <summary>
    /// Идентификатор документа.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Имя документа.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Контент документа.
    /// </summary>
    string Content { get; }

    /// <summary>
    /// Описание документа.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Флаг составного документа.
    /// </summary>
    bool IsComposite { get; }
  }
}