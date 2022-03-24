using SaveDocuments.Renderer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Document
{
  /// <summary>
  /// Документ содержащий другие документы.
  /// </summary>
  internal sealed class CompositeDocument : IDocument
  {
    #region Поля и свойства

    /// <summary>
    /// Коллекция документов.
    /// </summary>
    private readonly Dictionary<int, IDocument> documents = new Dictionary<int, IDocument>();
    
    #endregion

    #region IDocument

    public int Id { get; }

    public string Name { get; }

    public string Content { get; }

    public string Description => GetDescription();

    public void Accept(IRenderer renderer)
    {
      renderer.BeginVisitComposite(this);
      foreach(var document in this.documents.Values)
      {
        document.Accept(renderer);
      }
      renderer.EndVisitComposite(this);
    }

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет документ в коллекцию.
    /// </summary>
    /// <param name="child">Документ.</param>
    public void Add(IDocument child)
    {
      this.documents.Add(child.Id, child);
    }

    /// <summary>
    /// Удаляет документы из коллекции.
    /// </summary>
    /// <param name="child">Документ.</param>
    public void Remove(IDocument child)
    {
      this.documents.Remove(child.Id);
    }

    /// <summary>
    /// Получает строковое описание документа.
    /// </summary>
    /// <returns>Строковое описание документа.</returns>
    private string GetDescription()
    {
      var descriptionRenderer = new DescriptionRenderer();
      this.Accept(descriptionRenderer);

      return descriptionRenderer.ToString();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Имя.</param>
    public CompositeDocument(int id, string name) 
    {
      this.Id = id;
      this.Name = name;
    }

    #endregion
  }
}
