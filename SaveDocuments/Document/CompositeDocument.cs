using System.Collections.Generic;
using System.Text;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Документ содержащий другие документы.
  /// </summary>
  internal class CompositeDocument : SimpleDocument
  {
    #region Константы

    /// <summary>
    /// Здвиг описания внутренного документа.
    /// </summary>
    private const string DescriptionShift = "  ";

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Коллекция документов.
    /// </summary>
    private readonly Dictionary<int, SimpleDocument> documents = new Dictionary<int, SimpleDocument>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить документ в коллекцию.
    /// </summary>
    /// <param name="child">Документ.</param>
    public void Add(SimpleDocument child)
    {
      this.documents.Add(child.Id, child);
    }

    /// <summary>
    /// Удалить документ из коллекции.
    /// </summary>
    /// <param name="child">Документ.</param>
    public void Remove(SimpleDocument child)
    {
      this.documents.Remove(child.Id);
    }

    #endregion

    #region Базовый класс

    public override IEnumerator<IDocument> GetEnumerator()
    {
      var inners = new List<IDocument>();
      foreach (var document in this.documents.Values)
      {
        if (!document.IsComposite)
          inners.Add(document);
        else
          inners.AddRange(document);
      }

      return inners.GetEnumerator();
    }

    public override string GetDescription(string prefix)
    {
      var description = new StringBuilder();
      description.Append(prefix + this.Name);

      var innerPrefix = DescriptionShift + prefix;
      foreach (var document in this.documents.Values)
      {
        description.AppendLine();
        description.Append(document.GetDescription(innerPrefix));
      }

      return description.ToString();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Имя.</param>
    public CompositeDocument(int id, string name) : base(id, name, string.Empty)
    {
      this.IsComposite = true;
    }

    #endregion
  }
}
