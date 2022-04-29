using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using UsingCsvHelper.Model;

// LerCSVComDynamic();
// LerCSVComClasse();
//LerCSVComOutroDelimitador();
EscreverCSV();

Console.WriteLine("Digite [enter] para finalizar.");
Console.ReadLine();

static void EscreverCSV()
{
  var path = Path.Combine(
    Environment.CurrentDirectory,
    "Saida");

  var di = new DirectoryInfo(path);

  if (!di.Exists)
    di.Create();

  path = Path.Combine(path, "usuarios.csv");

  var pessoas = new List<Pessoa>(){
    new Pessoa() {
      Nome = "Emerson Carvalho",
      Email = "ec@gmail.com",
      Telefone = "11111111",
    },
    new Pessoa() {
      Nome = "Emanuel Carvalho",
      Email = "emc@gmail.com",
      Telefone = "22222222",
    },
    new Pessoa() {
      Nome = "Vagna Carvalho",
      Email = "vc@gmail.com",
      Telefone = "33333333",
    },
  };

  using var sr = new StreamWriter(path);
  var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
  {
    Delimiter = "|"
  };
  using var csvWriter = new CsvWriter(sr, csvConfig);
  csvWriter.WriteRecords(pessoas);

}

static void LerCSVComOutroDelimitador()
{
  var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "livros-preco-com-virgula.csv");
  var fi = new FileInfo(path);

  if (!fi.Exists)
    throw new FileNotFoundException($"O arquivo {path} não existe!");

  using var sr = new StreamReader(fi.FullName);
  var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
  {
    Delimiter = ";"
  };

  using var csvReader = new CsvReader(sr, csvConfig);
  csvReader.Context.RegisterClassMap<UsingCsvHelper.Mapping.LivroMap>();

  var registros = csvReader.GetRecords<Livro>().ToList();

  foreach (var registro in registros)
  {
    Console.WriteLine($"Titulo: {registro.Titulo}");
    Console.WriteLine($"Preço: {registro.Preco}");
    Console.WriteLine($"Autor: {registro.Autor}");
    Console.WriteLine($"Data de Lançamento: {registro.Lancamento}");
    Console.WriteLine("---------------------");
  }
}

static void LerCSVComClasse()
{
  var path = Path.Combine(
  Environment.CurrentDirectory,
  "Entrada",
  "usuarios-exportacao.csv");
  var fi = new FileInfo(path);

  if (!fi.Exists)
    throw new FileNotFoundException($"O arquivo {path} não existe!");

  using var sr = new StreamReader(fi.FullName);
  var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
  using var csvReader = new CsvReader(sr, csvConfig);

  var registros = csvReader.GetRecords<Usuario>();

  foreach (var registro in registros)
  {
    Console.WriteLine($"Nome: {registro.Nome}");
    Console.WriteLine($"Email: {registro.Email}");
    Console.WriteLine($"Telefone: {registro.Telefone}");
    Console.WriteLine("---------------------");
  }
}

static void LerCSVComDynamic()
{
  var path = Path.Combine(
  Environment.CurrentDirectory,
  "Entrada",
  "Produtos.csv"
);

  var fi = new FileInfo(path);

  if (!fi.Exists)
    throw new FileNotFoundException($"O arquivo {path} nãp existe!");

  using var sr = new StreamReader(fi.FullName);
  var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
  using var csvReader = new CsvReader(sr, csvConfig);

  var registros = csvReader.GetRecords<dynamic>();

  foreach (var registro in registros)
  {
    Console.WriteLine($"Nome: {registro.Produto}");
    Console.WriteLine($"Marca: {registro.Marca}");
    Console.WriteLine($"Preço: {registro.Preco}");
    Console.WriteLine("---------------------");
  }
}