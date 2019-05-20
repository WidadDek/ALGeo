using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlGeo
{
    class Securite
    {

        //cette methode permet de crypter une chaine en lui correspondant une autre chain cryptee
        public string EncryptPassword(string textPassword)
        {
            //Crypter le mot de passe          
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(textPassword);
            string encryptPass = Convert.ToBase64String(passBytes);
            return encryptPass;
        }
        //cette methode permet de decryter une chaine cryptee poor la rendre lisible et comprehensible
        public string DecryptPassword(string encryptedPassword)
        {
            //Decrypter le mot de passe    
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }
    }
}
