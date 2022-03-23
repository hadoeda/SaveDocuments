using SaveDocuments.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDocuments
{
  class Program
  {
    #region Константы
    private const string DocOption = "--doc";

    private const string DirOption = "--dir";
    
    private const string EncryptOption = "--encrypt";
    
    private const string ZipOption = "--zip";
    #endregion

    #region Методы
    static void Main(string[] args)
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

    static CommandLineOptions ParseCommandLine(string [] args)
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

    static void PrintHelp()
    {
      Console.WriteLine("Help:");
      Console.WriteLine($"{DocOption}=something   Document id.");
      Console.WriteLine($"{DirOption}=something   Export directory.");
      Console.WriteLine($"{EncryptOption}         Encrypt directory files.");
      Console.WriteLine($"{ZipOption}             Zip directory files.");
    }
    #endregion
  }

  class CommandLineOptions
  {
    public int DocumentId { get; set; }
    public string DirectoryPath { get; set; }
    public bool Encrypt { get; set; }
    public bool Zip { get; set; }
  }
}
