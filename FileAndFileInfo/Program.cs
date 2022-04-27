using static System.Console;

WriteLine("Digite o nome do arquivo: ");
var nome = ReadLine();

nome = LimparNome(nome);

var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");

CriarArquivo(path);

WriteLine("Digite enter para finalizar.");
ReadLine();

static string LimparNome(string nome)
{
  foreach (var @char in Path.GetInvalidFileNameChars())
  {
    nome = nome.Replace(@char, '-');
  }
  return nome;
}

static void CriarArquivo(string path)
{
  try
  {
    using var sw = File.CreateText(path);
    sw.WriteLine("Linha 1 do Arquivo");
    sw.WriteLine("Linha 2 do Arquivo");
    sw.WriteLine("Linha 3 do Arquivo");
    sw.WriteLine("Linha 4 do Arquivo");
    sw.WriteLine("Linha 5 do Arquivo");
  }
  catch
  {
    WriteLine("O nome do arquivo é inválido!");
  }
}
