using SaveDocuments.Document;
using System;
using System.Collections.Generic;

namespace SaveDocuments.Visitor
{
  /// <summary>
  /// Посетитель для сбора контента документа.
  /// </summary>
  internal class DocumentContentCollectVisitor : IVisitor
  {
    #region Поля и свойства

    /// <summary>
    /// Контент файлов.
    /// </summary>
    private readonly List<FileContent> content = new List<FileContent>();

    /// <summary>
    /// Результат.
    /// </summary>
    public IEnumerable<FileContent> Result => this.content;

    #endregion

    #region IVisitor

    public void BeginVisit(IDocument document)
    {
      this.content.Add(new FileContent(document.Name, Array.Empty<byte>()));
    }

    public void BeginVisitComposite(IDocument composite)
    { }

    public void EndVisit(IDocument document)
    { }

    public void EndVisitComposite(IDocument composite)
    { }

    #endregion
  }

  /// <summary>
  /// Имя файла и его контент.
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
