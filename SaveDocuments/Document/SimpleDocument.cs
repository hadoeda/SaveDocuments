using SaveDocuments.Visitor;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Простой документ.
  /// </summary>
  internal sealed class SimpleDocument : IDocument
  {
    #region Методы

    /// <summary>
    /// Создать пустой простой документ.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Простой пустой документ.</returns>
    public static SimpleDocument CreateEmpty(int id)
    {
      return new SimpleDocument(id, $"default {id}", "default");
    }

    #endregion

    #region IDocument

    public int Id { get; }

    public string Name { get; }

    public string Content { get; }

    public string Description => this.Name;

    public void Accept(IVisitor visitor)
    {
      visitor.BeginVisit(this);
      visitor.EndVisit(this);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор документа.</param>
    /// <param name="name">Имя документа.</param>
    /// <param name="content">Содержимое документа.</param>
    public SimpleDocument(int id, string name, string content)
    {
      this.Id = id;
      this.Name = name;
      this.Content = content;
    }

    #endregion
  }
}
