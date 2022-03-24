using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    #region Методы
    
    /// <summary>
    /// Стандартная точка входа в приложение.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
      var executor = new DocumentOperator();
      try
      {
        if (args.Length == 0)
          PrintHelp();
        else
        {
          var options = ParseCommandLine(args);
          executor.DoOperation(options);
        }
      }
      catch(Exception e)
      {
        Console.WriteLine(e.Message);
      }

      Console.ReadLine();
    }

    /// <summary>
    /// Парсит аргументы командной строки.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Опции для экспорта документа.</returns>
    private static CommandLineOptions ParseCommandLine(string [] args)
    {
      var result = new CommandLineOptions();
      foreach (var arg in args)
      {
        if (arg.Contains(DirOption))
        {
          var dirArgParts = arg.Split('=');
          if (dirArgParts.Length < 2) throw new Exception("Не указана папка для экспорта");

          result.DirectoryPath = dirArgParts[1];
        }
        else if (arg.Contains(DocOption))
        {
          var docArgParts = arg.Split('=');
          if (docArgParts.Length < 2) throw new Exception("Не указан идентификатор документа");

          if (!int.TryParse(docArgParts[1], out int id))
            result.DocumentId = id;
        }
        else if (arg == EncryptOption)
          result.Encrypt = true;
        else if (arg == ZipOption)
          result.Zip = true;
      }

      if (string.IsNullOrEmpty(result.DirectoryPath)) throw new Exception("Не указана папка для экспорта");

      return result;
    }


    /// <summary>
    /// Печатает справку.
    /// </summary>
    private static void PrintHelp()
    {
      Console.WriteLine("Help:");
      Console.WriteLine($"{DocOption}=something   Document id.");
      Console.WriteLine($"{DirOption}=something   Export directory.");
      Console.WriteLine($"{EncryptOption}         Encrypt directory files.");
      Console.WriteLine($"{ZipOption}             Zip directory files.");
    }

    #endregion
  }

  /// <summary>
  /// Опции экспорта документа.
  /// </summary>
  internal class CommandLineOptions
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
}
