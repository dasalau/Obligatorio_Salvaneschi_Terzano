namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public static class ContraseniaUtils
    {

        //Se genera una contraseña aleatoria de una longitud especificada (por defecto 8 caracteres)
        public static string GenerarContrasenia(int numchar = 8)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var contrasenia = new char[numchar];
            for (int i = 0; i < numchar; i++)
            {
                contrasenia[i] = chars[random.Next(chars.Length)];
            }

            return new string(contrasenia);

        }
    }
}
