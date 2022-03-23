using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Renderer
{
  /// <summary>
  /// Собирает контент файлов
  /// </summary>
  internal class FileRenderer : IRenderer
  {
    private readonly List<FileContent> content = new List<FileContent>();

    public IEnumerable<FileContent> Contents => content;

    public void BeginVisit(IDocument document)
    {
      content.Add(new FileContent(document.Name, Array.Empty<byte>()));
    }

    public void BeginVisitComposite(IDocument composite)
    {}

    public void EndVisit(IDocument document)
    {}

    public void EndVisitComposite(IDocument composite)
    {}
  }

  /// <summary>
  /// Запись содержит имя файла и его контент
  /// </summary>
  internal class FileContent
  {
    /// <summary>
    /// Имя файла
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Контент
    /// </summary>
    public byte[] Content { get; }

    public FileContent(string name, byte[] content)
    {
      this.Name = name;
      this.Content = content;
    }
  }
}
