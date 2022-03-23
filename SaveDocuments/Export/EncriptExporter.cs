using SaveDocuments.Document;
using SaveDocuments.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Export
{
  internal class EncriptExporter : IDocumentExporter
  {
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для шифрования
    /// </summary>
    private readonly EncryptProvider provider;

    public string Path => exporter.Path;

    public void Export(IDocument document)
    {
      this.exporter.Export(document);
      Console.WriteLine();
      this.provider.Encript(this.Path);
    }

    public EncriptExporter(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
      this.provider = new EncryptProvider();
    }
  }
}
