using System.Globalization;
using CsvHelper.Configuration;

namespace UsingCsvHelper.Mapping
{
  public class LivroMap : ClassMap<Model.Livro>
  {
    public LivroMap()
    {
      Map(x => x.Titulo).Name("titulo");
      Map(x => x.Preco)
        .Name("preço")
        .TypeConverterOption
        .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
      Map(x => x.Autor).Name("autor");
      Map(x => x.Lancamento)
        .Name("lançamento")
        .TypeConverterOption
        .Format(new[] { "dd/MM/yyyy" });
    }
  }
}