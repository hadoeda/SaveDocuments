using SaveDocuments.Document;
using SaveDocuments.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортирует документ в директорию. 
  /// </summary>
  internal class SimpleExporter : IDocumentExporter
  {
    #region IDocumentExporter

    public string Path { get; private set; }

    public void Export(IDocument document)
    {
      var fileContent = new FileRenderer();
      document.Accept(fileContent);
      
      foreach(var file in fileContent.Contents)
      {
        Console.WriteLine("Файл с именем {0} экспортирован в папку {1}", file.Name, Path);
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
    public SimpleExporter(string path)
    {
      this.Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    #endregion
  }
}
