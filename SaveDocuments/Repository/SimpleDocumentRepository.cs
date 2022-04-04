using SaveDocuments.Document;
using System;

namespace SaveDocuments.Repository
{
  /// <summary>
  /// Простой репозиторий.
  /// Заглушка, возвращающая всегда один документ.
  /// </summary>
  internal sealed class SimpleDocumentRepository : IDocumentRepository
  {
    #region Поля и свойства

    /// <summary>
    /// Документ.
    /// </summary>
    private readonly IDocument document;

    #endregion

    #region IDocumentRepository

    public IDocument Get(int id)
    {
      return this.document;
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор
    /// </summary>
    public SimpleDocumentRepository()
    {
      var composite1 = new CompositeDocument(1, "Комплект 1");
      var composite2 = new CompositeDocument(2, "Комплект 2");
      composite2.Add(new SimpleDocument(3, "Документ 3", "Документ 3"));
      composite2.Add(new SimpleDocument(4, "Документ 4", "Документ 4"));
      composite2.Add(new SimpleDocument(5, "Документ 5", "Документ 5"));
      composite1.Add(composite2);
      composite1.Add(new SimpleDocument(6, "Документ 6", "Документ 6"));

      this.document = composite1;
    }

    #endregion
  }
}
