using SaveDocuments.Visitor;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Документ.
  /// </summary>
  internal interface IDocument
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
    /// Примененить посетителя.
    /// </summary>
    /// <param name="visitor">Посетитель.</param>
    void Accept(IVisitor visitor);
  }
}