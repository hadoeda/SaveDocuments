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
  /// Документ содержащий другие документы
  /// </summary>
  internal class CompositeDocument : IDocument
  {
    #region Поля и свойства
    /// <summary>
    /// Коллекция документов
    /// </summary>
    private readonly Dictionary<int, IDocument> documents = new Dictionary<int, IDocument>();

    public int Id { get; }

    public string Name { get; }

    public string Content { get; }

    public string Description => GetDescription();
    #endregion

    #region IDocument
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
    public void Add(IDocument child)
    {
      this.documents.Add(child.Id, child);
    }

    public void Remove(IDocument child)
    {
      this.documents.Remove(child.Id);
    }

    public string GetDescription()
    {
      var descriptionRenderer = new DescriptionRenderer();
      this.Accept(descriptionRenderer);

      return descriptionRenderer.ToString();
    }
    #endregion

    #region Конструкторы
    public CompositeDocument(int id, string name) 
    {
      this.Id = id;
      this.Name = name;
    }
    #endregion
  }
}
