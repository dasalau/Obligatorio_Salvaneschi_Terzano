using System.Text;
using System.Text.RegularExpressions;
namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class MailUtils
    {

        public static string GetMail(string nombre, string apellido, bool existeMail)
        {
            string nombremail;
            nombremail = nombre.Substring(0, nombre.Length < 3 ? nombre.Length : 3).ToLower() +
               apellido.Substring(0, apellido.Length < 3 ? apellido.Length : 3).ToLower();
            nombremail = RemoverAcentos(nombremail); //Se remueven los acentos

            if (!existeMail)
            {
                return nombremail + "@empresa.com";
            }

            Random random = new Random();  //variable para generar números aleatorios
            nombremail += random.Next(1000, 10000); //Añade un número aleatorio entre 1000 y 9999

            return nombremail + "@empresa.com";

        }

        private static string RemoverAcentos(string texto)
        {
            // Normaliza en FormD: separa caracteres base de los acentos/diacríticos
            string normalizado = texto.Normalize(NormalizationForm.FormD);

            // Regex para eliminar caracteres diacríticos (Mark, NonSpacing)
            Regex regex = new Regex(@"\p{Mn}");

            string sinAcentos = regex.Replace(normalizado, "");

            // Ahora sustituimos ñ → n explícitamente
            sinAcentos = sinAcentos.Replace("ñ", "n").Replace("Ñ", "N");

            return sinAcentos;

        }
    }
}
