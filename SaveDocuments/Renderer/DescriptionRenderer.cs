using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Renderer
{

  /// <summary>
  /// Формирует описание докмента.
  /// </summary>
  internal class DescriptionRenderer : IRenderer
  {
    #region Поля и свойства

    /// <summary>
    /// Описание документа.
    /// </summary>
    private readonly StringBuilder builder = new StringBuilder();

    /// <summary>
    /// Уровень вложенности.
    /// </summary>
    private int deepLevel = 0;
    
    #endregion

    #region IRenderer

    public void BeginVisit(IDocument document)
    {
      builder.AppendLine(new string(' ', 2 * deepLevel) + document.Name);
    }

    public void EndVisit(IDocument document)
    {}

    public void BeginVisitComposite(IDocument composite)
    {
      builder.AppendLine(new string(' ', 2 * deepLevel) + composite.Name);
      deepLevel++;
    }

    public void EndVisitComposite(IDocument composite)
    {
      deepLevel--;
    }

    #endregion

    #region Базовый класс

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Описание документа.</returns>
    public override string ToString()
    {
      return builder.ToString();
    }

    #endregion
  }
}
