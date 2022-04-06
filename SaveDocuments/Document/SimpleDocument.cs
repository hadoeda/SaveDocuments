using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Простой документ.
  /// </summary>
  internal class SimpleDocument : IDocument
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

    /// <summary>
    /// Получить описание документа.
    /// </summary>
    /// <param name="prefix">Префикс описания.</param>
    /// <returns>Описание документа.</returns>
    public virtual string GetDescription(string prefix)
    {
      return prefix + this.Name;
    }

    #endregion

    #region IDocument

    public int Id { get; }

    public string Name { get; }

    public string Content { get; }

    public string Description => GetDescription(string.Empty);

    public bool IsComposite { get; protected set; }

    #endregion

    #region IEnumerable<IDocument>

    public virtual IEnumerator<IDocument> GetEnumerator()
    {
      return Enumerable.Empty<IDocument>().GetEnumerator();
    }

    #endregion

    #region IEnumerable

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
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
      this.IsComposite = false;
    }

    #endregion
  }
}
