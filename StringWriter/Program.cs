string textReaderText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
  "Quisque vehicula viverra neque, id pellentesque nibh pharetra eget." +
  "Nulla sit amet aliquam massa. Vestibulum a tempus purus, eu finibus justo." +
  "Aliquam sollicitudin ex erat, eu placerat quam molestie ut.\n\n" +

  "Etiam laoreet pharetra ligula, ac cursus dui interdum quis. " +
  "Pellentesque sed libero tincidunt, consequat enim at, auctor nunc." +
  "Sed tincidunt sit amet massa in dapibus. Pellentesque consequat ullamcorper lorem, at mollis nulla ultrices eu.\n\n" +

  "Cras luctus augue non eros auctor, a aliquet turpis egestas." +
  "Etiam condimentum, quam ac malesuada tincidunt, est eros molestie sapien," +
  "sed auctor ligula justo interdum felis.\n\n";

Console.WriteLine($"Texto original: {textReaderText}");
string linha, paragrafo = null;
var sr = new StringReader(textReaderText);

while (true)
{
  linha = sr.ReadLine();
  if (linha != null)
  {
    paragrafo += linha + " ";
  }
  else
  {
    paragrafo += '\n';
    break;
  }
}

Console.WriteLine($"Texto modificado: {paragrafo}");
int caractereLido;
char caractereConvertido;

var sw = new StringWriter();
sr = new StringReader(paragrafo);

while (true)
{
  caractereLido = sr.Read();
  if (caractereLido == -1) break;

  caractereConvertido = Convert.ToChar(caractereLido);

  if (caractereLido == '.')
  {
    sw.Write("\n\n");

    sr.Read();
    sr.Read();
  }
  else
  {
    sw.Write(caractereConvertido);
  }

}

Console.WriteLine($"Texto armazenado no StringWriter: {sw.ToString()}");
Console.ReadKey();