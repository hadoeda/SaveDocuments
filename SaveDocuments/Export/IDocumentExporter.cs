using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Export
{
  internal interface IDocumentExporter
  {
    /// <summary>
    /// Директория
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Экспорт документа 
    /// </summary>
    /// <param name="document">Документ</param>
    void Export(IDocument document);
  }
}
