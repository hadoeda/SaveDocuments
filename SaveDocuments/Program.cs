using SaveDocuments.Export;
using SaveDocuments.Repository;
using System;
using System.Text.RegularExpressions;

namespace SaveDocuments
{
  /// <summary>
  /// Основной класс приложения.
  /// </summary>
  public class Program
  {
    #region Константы

    /// <summary>
    /// Аргумент командной строки.
    /// Указывающий идентификатор документа.
    /// </summary>
    private const string DocOption = "--doc";

    /// <summary>
    /// Аргумент командной строки.
    /// Указывающий директорию экспорта документа.
    /// </summary>
    private const string DirOption = "--dir";

    /// <summary>
    /// Аргумент командной строки.
    /// Включает шифрование файлов документов.
    /// </summary>
    private const string EncryptOption = "--encrypt";

    /// <summary>
    /// Аргумент командной строки.
    /// Включает архивирование файлов документов.
    /// </summary>
    private const string ZipOption = "--zip";

    #endregion

    #region Вложенные типы

    /// <summary>
    /// Опции экспорта документа.
    /// </summary>
    private class CommandLineOptions
    {
      #region Поля и свойства

      /// <summary>
      /// Идентификатор документа.
      /// </summary>
      public int DocumentId { get; set; }

      /// <summary>
      /// Директория экспорта.
      /// </summary>
      public string DirectoryPath { get; set; }

      /// <summary>
      /// Опция шифрования документа.
      /// </summary>
      public bool Encrypt { get; set; }

      /// <summary>
      /// Опция архивирования документа.
      /// </summary>
      public bool Zip { get; set; }

      #endregion
    }

    #endregion

    #region Методы

    /// <summary>
    /// Стандартная точка входа в приложение.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      try
      {
        if (args.Length == 0)
        {
          PrintHelp();
        }
        else
        {
          var options = ParseCommandLine(args);
          ExportDocuments(options);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.ReadLine();
    }

    /// <summary>
    /// Распарсить аргументы командной строки.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Опции для экспорта документа.</returns>
    private static CommandLineOptions ParseCommandLine(string[] args)
    {
      var result = new CommandLineOptions();
      foreach (var arg in args)
      {
        if (arg.Contains(DirOption))
        {
          var dirArgParts = arg.Split('=');
          if (dirArgParts.Length < 2)
            throw new ArgumentException("Не указана папка для экспорта.");

          result.DirectoryPath = ParseDirectory(dirArgParts[1]);
        }
        else if (arg.Contains(DocOption))
        {
          var docArgParts = arg.Split('=');
          if (docArgParts.Length < 2)
            throw new ArgumentException("Не указан идентификатор документа.");

          if (int.TryParse(docArgParts[1], out int id))
            result.DocumentId = id;
          else
            throw new ArgumentException("Неверно указан идентификатор документа.");
        }
        else if (arg == EncryptOption)
        {
          result.Encrypt = true;
        }
        else if (arg == ZipOption)
        {
          result.Zip = true;
        }
      }

      if (string.IsNullOrEmpty(result.DirectoryPath))
        throw new ArgumentException("Не указана папка для экспорта.");

      return result;
    }

    /// <summary>
    /// Экспортировать докуметы.
    /// <param name="options">Опции экспорта.</param>
    /// </summary>
    private static void ExportDocuments(CommandLineOptions options)
    {
      IDocumentRepository source = new SimpleDocumentRepository();

      var exporter = new DirectoryExporter(options.DirectoryPath);
      if (options.Encrypt) exporter = new EncryptExporter(exporter);
      if (options.Zip) exporter = new ArchExporter(exporter);

      var document = source.Get(options.DocumentId);
      exporter.Export(document);
    }

    /// <summary>
    /// Pаcпарсить путь к директории из аргумента.
    /// </summary>
    /// <param name="arg">Аргумент командной строки.</param>
    /// <returns>Путь к директории.</returns>
    private static string ParseDirectory(string arg)
    {
      string result = arg;
      var pathQuotes = new Regex("[', \"](.+)[', \"]");
      var matches = pathQuotes.Matches(arg);
      if (matches.Count == 0)
        return result;

      result = matches[0].Groups[1].Value;

      return result;
    }

    /// <summary>
    /// Напечать справку.
    /// </summary>
    private static void PrintHelp()
    {
      Console.WriteLine("Справка:");
      Console.WriteLine($"{DocOption}=something   Идентификатор документа.");
      Console.WriteLine($"{DirOption}='something' Папка экспорта.");
      Console.WriteLine($"{EncryptOption}         Флаг шифрования экспортированных файлов.");
      Console.WriteLine($"{ZipOption}             Флаг архивации экспортированных файлов");
    }

    #endregion
  }
}
