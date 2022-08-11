using ServicesAdministration.CORE.Helpers.Interfaces;
using System.Text;

namespace ServicesAdministration.CORE.Helpers
{
    public class EncriptAndDesencriptPassword : IEncriptAndDesencriptPassword
    {

        #region Dependency

        #endregion

        #region Constructor
        public EncriptAndDesencriptPassword()
        {

        }
        #endregion

        #region Methods
        public async Task<string> Desencript(string password)
        {
            var encoder = new UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecodeByte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return await Task.FromResult(result);
        }


        public async Task<string> Encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return await Task.FromResult(msg);
        }

        #endregion
    }
}
