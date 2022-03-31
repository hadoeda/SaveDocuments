using SaveDocuments.Document;

namespace SaveDocuments.Visitor
{
  /// <summary>
  /// Посетитель документов.
  /// </summary>
  internal interface IVisitor
  {
    /// <summary>
    /// Посетить составной документ.
    /// </summary>
    /// <param name="composite">Составной документ.</param>
    void BeginVisitComposite(IDocument composite);

    /// <summary>
    /// Завершить посещение составного документа.
    /// </summary>
    /// <param name="composite">Составной документ.</param>
    void EndVisitComposite(IDocument composite);

    /// <summary>
    /// Посетить документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    void BeginVisit(IDocument document);

    /// <summary>
    /// Завершить посещение документа.
    /// </summary>
    /// <param name="document">Документ.</param>
    void EndVisit(IDocument document);
  }
}
