using System.IO;
using Microsoft.AspNetCore.Mvc;
using TrioSimulator.Models;

namespace TrioSimulator.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("api/v1/mgmt/device/info")]
        public IActionResult Info()
        {
            DeviceInfoAttachedHardwareModel infoAttachedHardwareModel = new DeviceInfoAttachedHardwareModel();

            DeviceInfoDataModel infoDataModel = new DeviceInfoDataModel();
            infoDataModel.DeviceType = "hardwareEndpoint";
            infoDataModel.IPV4Address = "10.187.85.73";
            infoDataModel.ModelNumber = "Trio 8800";
            infoDataModel.DeviceVendor = "Polycom";
            infoDataModel.FirmwareRelease = "5.7.1.4095";
            infoDataModel.UpTimeSinceLastReboot = "0 Day 0:12:25";
            infoDataModel.MACAddress = "64167f298aea";
            infoDataModel.IPV6Address = "::";
            infoDataModel.AttachedHardware = infoAttachedHardwareModel;

            DeviceInfoModel infoModel = new DeviceInfoModel();
            infoModel.data = infoDataModel;
            infoModel.Status = "2000";

            // Middleware will take care of the headers
            // Alternatively
            // - Request.HttpContext.Response.Headers.Add("Server", "Polycom SoundPoint IP Telephone HTTPd"); 
            // - HttpContext.Response.ContentType = "application/json";            
            
            if (!Request.HttpContext.Request.Headers.Keys.Contains("Authorization"))
            {
                // Return a 401 to simulate BASIC auth
                // Middleware will take care of the headers
                // Alternatively
                // - HttpContext.Response.StatusCode = 401;
                // - Request.HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"API Authentication\"");

                return Unauthorized();
            }

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader("response.txt");
            string jsonTxtResponse = file.ReadLine();
            file.Close();

            return Content(jsonTxtResponse.TrimEnd()); // return from JSON txt
            // return Ok(infoModel); // return the object
        }

        [HttpGet("api/v1/mgmt/lineinfo")]
        public IActionResult LineInfo()
        {
            LineInfoDataModel lineInfoDataModel = new LineInfoDataModel();
            lineInfoDataModel.LineNumber = "1";
            lineInfoDataModel.RegistrationStatus = "registered";
            lineInfoDataModel.UserID = "1234";
            lineInfoDataModel.Label = "+1234";
            lineInfoDataModel.LineType = "private";
            lineInfoDataModel.SIPAddress = "1234";
            lineInfoDataModel.Port = "5060";
            lineInfoDataModel.Protocol = "SIP";
            lineInfoDataModel.ProxyAddress = "10.187.80.66";

            LineInfoModel lineInfoModel = new LineInfoModel();
            lineInfoModel.data = lineInfoDataModel;
            lineInfoModel.Status = "2000";

            return Ok(lineInfoModel);
        }

        [HttpGet("api/v1/webcallcontrol/callstatus")]
        public IActionResult CallStatus()
        {
            CallStatusDataModel callStatusDataModel = new CallStatusDataModel();
            callStatusDataModel.LineId = "1";
            callStatusDataModel.RemotePartyName = "tel:1234";
            callStatusDataModel.Type = "Outgoing";
            callStatusDataModel.Protocol = "Sip";
            callStatusDataModel.CallState = "Connected";
            callStatusDataModel.RemotePartyNumber = "tel:1234";
            callStatusDataModel.DurationInSeconds = "45";

            CallStatusModel callStatusModel = new CallStatusModel();
            callStatusModel.data = callStatusDataModel;
            callStatusModel.Status = "2000";
        }

        [HttpGet("")]
        public IActionResult Default()
        {
            return Ok("pong");
        }
    }
}
