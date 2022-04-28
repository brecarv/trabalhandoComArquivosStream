using System.Text;

var sb = new StringBuilder();
sb.AppendLine("Caracteres na primeira linha para ler");
sb.AppendLine("Caracteres na segunda linha para ler");
sb.AppendLine("Caracteres na última linha para ler");

using var sr = new StringReader(sb.ToString());
var buffer = new char[10];
var tamanho = 0;

do
{
  Console.WriteLine(sr.ReadLine());
} while (sr.Peek() >= 0);

// do
// {
//   buffer = new char[10];
//   tamanho = sr.Read(buffer);
//   Console.Write(string.Join("", buffer));
// } while (tamanho >= buffer.Length);

Console.WriteLine("Pressione [enter] para finalizar.");
Console.ReadKey();