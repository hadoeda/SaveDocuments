using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Repository
{
  internal class SimpleDocumentRepository : IDocumentRepository
  {
    private readonly IDocument document;

    public IDocument Get(int id)
    {
      return this.document;
    }

    public void Save(IDocument document)
    {
      Console.WriteLine("Сохранение документа {0} в репозиторий", document.Name);
    }

    public SimpleDocumentRepository()
    {
      var document = new CompositeDocument(1, "Комплект 1");
      var innerDocument = new CompositeDocument(2, "Комплект 2");
      innerDocument.Add(new SimpleDocument(3, "Документ 3", "Документ 3"));
      innerDocument.Add(new SimpleDocument(4, "Документ 4", "Документ 4"));
      innerDocument.Add(new SimpleDocument(5, "Документ 5", "Документ 5"));
      document.Add(innerDocument);
      document.Add(new SimpleDocument(6, "Документ 6", "Документ 6"));

      this.document = document;
    }
  }
}
