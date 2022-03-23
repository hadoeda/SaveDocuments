using SaveDocuments.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Document
{
  internal interface IDocument
  {
    /// <summary>
    /// Идентификатор документа
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Имя документа
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Контент документа
    /// </summary>
    string Content { get; }

    /// <summary>
    /// Описание документа
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Метод применения посетителя
    /// </summary>
    /// <param name="renderer">Посетитель</param>
    void Accept(IRenderer renderer);
  }
}
