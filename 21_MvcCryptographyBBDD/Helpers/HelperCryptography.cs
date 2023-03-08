using System.Security.Cryptography;
using System.Text;

namespace _21_MvcCryptographyBBDD.Helpers
{
    public class HelperCryptography
    {
        //TENDREMOS UN PAR DE METODOS QUE NO TIENEN NADA QUE VER CON CRIPTOGRAFIA, PERO QUE SERAN DE GRAN UTILIDAD
        public static string GenerateSalt()
        {
            //TENDREMOS UN SALT DE 24
            Random random = new Random();
            string salt = "";
            for(int i = 1; i <= 24; i++)
            {
                int aleat = random.Next(0, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }

            return salt;
        }

        //EN ALGUN MOMENTO TENDREMOS QUE COMPARAR SI LOS PASSWORD SON IGUALES
        public static bool CompareArray(byte[] a, byte[] b)
        {
            bool iguales = true;

            if(a.Length != b.Length)
            {
                iguales = false;
            } else
            {
                for(int i = 0; i < a.Length; i++)
                {
                    if (a[i].Equals(b[i]) == false)
                    {
                        iguales = false;
                        break;
                    }
                }
            }
            return iguales;
        }


        //TENDREMOS UN METODO PARA CIFRAR NUESTRO PASSWORD
        public static byte[] EncryptPassword(string password, string salt)
        {
            string contenido = password + salt;
            SHA512 sHA = SHA512.Create();

            //CONVERTIMOS NUESTRO CONTENIDO A BYTES[]
            byte[] salida = Encoding.UTF8.GetBytes(contenido);

            //LAS ITERACCIONES PARA NUESTRO PASSWORD
            for(int i = 1; i <= 24; i++)
            {
                salida = sHA.ComputeHash(salida);
            }

            sHA.Clear();

            return salida;
        }

        //TENEMOS UN METODO PARA SUBIR LA IMAGEN DEL USUARIO A NUESTRO LOCAL
        public enum Folders { Images = 0, Uploads = 1, Facturas = 2, Temporal = 3 }
        public static string UploadImage(IFormFile file, Folders folder)
        {
            string fileName = file.FileName;
            string path = this.helperPath.MapPath(fileName, folder);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return path;
        }


    }
}
