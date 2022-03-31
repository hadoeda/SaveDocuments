using SaveDocuments.Document;
using System.Text;

namespace SaveDocuments.Visitor
{
  /// <summary>
  /// Посетитель, формирующий описание документа.
  /// </summary>
  internal class DescriptionVisitor : IVisitor
  {
    #region Поля и свойства

    /// <summary>
    /// Результат.
    /// </summary>
    public string Result => builder.ToString();

    /// <summary>
    /// Описание документа.
    /// </summary>
    private readonly StringBuilder builder = new StringBuilder();

    /// <summary>
    /// Уровень вложенности.
    /// </summary>
    private int deepLevel = 0;

    #endregion

    #region IVisitor

    public void BeginVisit(IDocument document)
    {
      this.builder.AppendLine(new string(' ', 2 * this.deepLevel) + document.Name);
    }

    public void EndVisit(IDocument document)
    { }

    public void BeginVisitComposite(IDocument composite)
    {
      this.builder.AppendLine(new string(' ', 2 * this.deepLevel) + composite.Name);
      this.deepLevel++;
    }

    public void EndVisitComposite(IDocument composite)
    {
      this.deepLevel--;
    }

    #endregion
  }
}
