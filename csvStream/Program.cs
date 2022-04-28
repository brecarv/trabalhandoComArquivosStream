using static System.Console;

CriarCsv();

WriteLine("\n\n Pressione [enter] para sair...");
ReadLine();

static void CriarCsv()
{
  var path = Path.Combine(
  Environment.CurrentDirectory,
  "Saida");

  var pessoas = new List<Pessoa>() {
    new Pessoa(){
      Nome = "Emerson Carvalho",
      Email = "ec@ec.com",
      Telefone = 123456
    },
    new Pessoa(){
      Nome = "Emanuel Carvalho",
      Email = "emanuelc@ec.com",
      Telefone = 1123123
    },
    new Pessoa(){
      Nome = "Vagna Carvalho",
      Email = "vc@ec.com",
      Telefone = 1125231
    },
  };

  var di = new DirectoryInfo(path);
  if (!di.Exists)
  {
    di.Create();
    path = Path.Combine(path, "usuarios.csv");
  }
  using var sw = new StreamWriter(path);
  sw.WriteLine("nome,email,telefone");
  foreach (var pessoa in pessoas)
  {
    var linha = $"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone}";
    sw.WriteLine(linha);
  }
}

static void LerCsv()
{
  var path = Path.Combine(
  Environment.CurrentDirectory,
  "Entrada",
  "usuarios-exportacao.csv");
  if (File.Exists(path))
  {
    using var sr = new StreamReader(path);
    var cabecalho = sr.ReadLine()?.Split(',');

    while (true)
    {
      var registro = sr.ReadLine()?.Split(',');
      if (registro == null) break;
      if (cabecalho?.Length != registro.Length)
      {
        WriteLine("Arquivo fora do padrão.");
        break;
      }
      for (int i = 0; i < registro.Length; i++)
      {
        WriteLine($"{cabecalho?[i]}:{registro[i]}");
      }
      WriteLine("---------------------------");
    }
  }
  else
  {
    WriteLine($"O arquivo {path} não existe.");
  }
}

class Pessoa
{
  public string Nome { get; set; }
  public string Email { get; set; }
  public int Telefone { get; set; }

}