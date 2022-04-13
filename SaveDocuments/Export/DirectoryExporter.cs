using SaveDocuments.Document;
using System;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспорёр документов в директорию файловой системы.
  /// </summary>
  internal class DirectoryExporter : IDocumentExporter
  {

    #region IDocumentExporter

    public virtual void Export(IDocument document, string path)
    {
      if (document.IsComposite)
        foreach (var innerDoc in document.GetCollection())
        {
          Console.WriteLine("Файл с именем {0} экспортирован в папку {1}", innerDoc.Name, path);
        }
      else
        Console.WriteLine("Файл с именем {0} экспортирован в папку {1}", document.Name, path);

      Console.WriteLine();
      Console.WriteLine("-------------");
      Console.WriteLine("Описание экспортированного файла");
      Console.WriteLine(document.Description);
    }

    #endregion
  }
}
