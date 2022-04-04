using SaveDocuments.Document;
using SaveDocuments.Visitor;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспорёр документов в директорию файловой системы.
  /// </summary>
  internal class DirectoryExporter : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Путь к директории.
    /// </summary>
    public string Path { get; }

    #endregion

    #region IDocumentExporter
    public virtual void Export(IDocument document)
    {
      var fileContent = new DocumentContentCollectVisitor();
      document.Accept(fileContent);
      foreach (var file in fileContent.Result)
      {
        Console.WriteLine("Файл с именем {0} экспортирован в папку {1}", file.Name, this.Path);
      }

      Console.WriteLine("-------------");
      Console.WriteLine("Описание экспортированного файла");
      Console.WriteLine(document.Description);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="path"></param>
    /// <exception cref="ArgumentNullException">Пустой путь к директории.</exception>
    public DirectoryExporter(string path)
    {
      if (string.IsNullOrEmpty(path))
        throw new ArgumentNullException(nameof(path));

      this.Path = path;
    }

    #endregion
  }
}
