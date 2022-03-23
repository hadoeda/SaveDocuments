using SaveDocuments.Export;
using SaveDocuments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments
{
  internal class DocumentOperator
  {
    private readonly IDocumentRepository source = new SimpleDocumentRepository();

    public void DoOperation(CommandLineOptions options)
    {
      IDocumentExporter exporter = new SimpleExporter(options.DirectoryPath);
      if (options.Encrypt) exporter = new EncriptExporter(exporter);
      if (options.Zip) exporter = new ZipExporter(exporter);

      var destination = new DirectoryDocumentRepositor(exporter);
      var document = source.Get(options.DocumentId);
      destination.Save(document);
    }
  }
}
