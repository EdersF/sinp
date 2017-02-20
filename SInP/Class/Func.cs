using System;

namespace SInP
{
    public class Func
    {
        public int ConvertDataParaBD(string data)
        {
            int retorno = Convert.ToInt32(data.Substring(6, 4) + data.Substring(3, 2) + data.Substring(0, 2));
            return retorno;
        }

        public string ConvertDataParaUser(int data)
        {
            string retorno = data.ToString().Substring(6, 2) + "/" + data.ToString().Substring(4, 2) + "/" + data.ToString().Substring(0, 4);
            return retorno;
        }
    }

}
