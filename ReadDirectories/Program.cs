var path = @"D:\dev-workspace\DIO-Impulso-Fullstack\trabalhandoComArquivosStream\DirectoryAndDirectoryInfo\globo";

ReadDirectories(path);
Console.WriteLine("Digite enter para finalizar.");
Console.ReadLine();
static void ReadDirectories(string path)
{

  if (Directory.Exists(path))
  {
    var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
    foreach (var dir in directories)
    {
      var dirInfo = new DirectoryInfo(dir);
      Console.WriteLine($"[Nome]:{dirInfo.Name}");
      Console.WriteLine($"[Raiz]:{dirInfo.Root}");
      if (dirInfo.Parent != null)
        Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");

      Console.WriteLine("-----------------------------");
    }
  }
  else
  {
    Console.WriteLine($"{path} não existe!");
  }
}