using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Renderer
{
  /// <summary>
  /// Собирает контент файлов.
  /// </summary>
  internal class FileRenderer : IRenderer
  {
    #region Поля и свойства

    /// <summary>
    /// Контент файлов
    /// </summary>
    private readonly List<FileContent> content = new List<FileContent>();

    /// <summary>
    /// Контент файлов
    /// </summary>
    public IEnumerable<FileContent> Contents => content;

    #endregion

    #region IRenderer

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

    #endregion
  }

  /// <summary>
  /// Запись содержит имя файла и его контент.
  /// </summary>
  internal class FileContent
  {
    #region Поля и свойства

    /// <summary>
    /// Имя файла.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Контент.
    /// </summary>
    public byte[] Content { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="content">Контент.</param>
    public FileContent(string name, byte[] content)
    {
      this.Name = name;
      this.Content = content;
    }

    #endregion
  }
}
