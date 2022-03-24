using SaveDocuments.Export;
using SaveDocuments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments
{
  /// <summary>
  /// Класс выполняющий действия над документами.
  /// </summary>
  internal class DocumentOperator
  {
    #region Поля и свойства

    /// <summary>
    /// Репозиторий источник документов
    /// </summary>
    private readonly IDocumentRepository source = new SimpleDocumentRepository();

    #endregion

    #region Методы

    /// <summary>
    /// Выполняет операцию.
    /// </summary>
    /// <param name="options">Опции операции.</param>
    public void DoOperation(CommandLineOptions options)
    {
      IDocumentExporter exporter = new SimpleExporter(options.DirectoryPath);
      if (options.Encrypt) exporter = new EncryptExporter(exporter);
      if (options.Zip) exporter = new ZipExporter(exporter);

      var destination = new DirectoryDocumentRepositor(exporter);
      var document = source.Get(options.DocumentId);
      destination.Save(document);
    }

    #endregion
  }
}
