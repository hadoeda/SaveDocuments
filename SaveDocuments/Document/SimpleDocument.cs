using SaveDocuments.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Простой документ
  /// </summary>
  internal class SimpleDocument : IDocument
  {
    #region Методы
    /// <summary>
    /// Возвращает пустой простой документ
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Простой документ</returns>
    public static SimpleDocument Empty(int id)
    { 
      return new SimpleDocument(id, $"default {id}", "default"); 
    }
    #endregion

    #region IDocument
    public int Id { get; }

    public string Name { get; }

    public string Content { get; }

    public virtual string Description => this.Name;
    
    public void Accept(IRenderer renderer)
    {
      renderer.BeginVisit(this);
      renderer.EndVisit(this);
    }
    #endregion

    #region Конструкторы
    public SimpleDocument(int id, string name, string content)
    {
      this.Id = id;
      this.Name = name;
      this.Content = content;
    }
    #endregion
  }
}
