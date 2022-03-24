using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Renderer
{
  /// <summary>
  /// Посетитель документов.
  /// </summary>
  internal interface IRenderer
  {
    /// <summary>
    /// Посещает составной документ.
    /// </summary>
    /// <param name="composite">Составной документ.</param>
    void BeginVisitComposite(IDocument composite);
    
    /// <summary>
    /// Завершает посещение составного документа.
    /// </summary>
    /// <param name="composite">Составной документ.</param>
    void EndVisitComposite(IDocument composite);
    
    /// <summary>
    /// Посещает документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    void BeginVisit(IDocument document);
    
    /// <summary>
    /// Завершает посещение документа.
    /// </summary>
    /// <param name="document">Документ.</param>
    void EndVisit(IDocument document);
  }
}
