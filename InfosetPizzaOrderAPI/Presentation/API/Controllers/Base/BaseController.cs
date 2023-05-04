using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected string GetIpAddress()
        {
            /*
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            if (ipAddress == "::1")
                ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();            

            */
            string ipAddress = "88.226.107.184";
            return ipAddress;
        }
    }
}
/*
eminönü location ip address --> 161.9.22.46
sultanbeyli location ip address --> 81.214.164.134
kadıköy location ip address --> 88.226.107.184
string ipAddress = "161.9.22.46";       
*/
