﻿using SaveDocuments.Archiver;
using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments.Export
{
  /// <summary>
  /// Экспортирует документы в директорию.
  /// Архивирует файлы в директории.
  /// </summary>
  internal class ZipExporter : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Экспортер документов в директорию.
    /// </summary>
    private readonly IDocumentExporter exporter;

    /// <summary>
    /// Провайдер для архивирования
    /// </summary>
    private readonly ZipProvider provider;

    #endregion

    #region IDocumentExporter

    public string Path => exporter.Path;

    public void Export(IDocument document)
    {
      this.exporter.Export(document);
      Console.WriteLine();
      this.provider.Zip(this.Path, document.Name);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="exporter">Экспортер документов.</param>
    public ZipExporter(IDocumentExporter exporter)
    {
      this.exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
      this.provider = new ZipProvider();
    }

    #endregion
  }
}
