using System.Security.Cryptography;
using System.Text;

namespace RelatoriosWeb.Classe
{
    public class Criptografia
    {

        #region Atributo da Classe Criptografia
        private HashAlgorithm _algoritmo;
        #endregion

        #region Construtor
        public Criptografia(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }
        #endregion

        #region Criptografa a Senha
        public string CriptografarSenha(string sSenha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(sSenha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }
        #endregion
    }
}