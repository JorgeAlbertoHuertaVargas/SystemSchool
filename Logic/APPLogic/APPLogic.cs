using Data.Functions;
using System;
using System.Threading.Tasks;
namespace Logic.APPLogic
{
    public class APPLogic
    {
        APIFunctions appfuction = new APIFunctions();

        public async Task<string> ConsultarDNIAsync(string dNItext)
        {
            try
            {
                Task<String> repuestadni = appfuction.Consulta_DNIsyncAsync(dNItext);
                String result = await repuestadni;
                return result;
            }
            catch (Exception e)
            {
                throw new("Failed extraerd data!.", e);
            }
        }
    }
}