using SaveDocuments.Archiver;
using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Export
{
  class ZipExporter : IDocumentExporter
  {
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для архивирования
    /// </summary>
    private readonly ZipProvider provider;

    public string Path => exporter.Path;

    public void Export(IDocument document)
    {
      this.exporter.Export(document);
      Console.WriteLine();
      this.provider.Zip(this.Path, document.Name);
    }

    public ZipExporter(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
      this.provider = new ZipProvider();
    }
  }
}
