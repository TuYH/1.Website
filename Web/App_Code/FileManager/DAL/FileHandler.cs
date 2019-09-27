using System;
using System.IO;
using System.Web;
namespace ptw.FileManager.Web.HttpHandlers
{
    public class FileHandler : IHttpHandler
    {
        public FileHandler()
        { 
        }

        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["file"];

            if (File.Exists(fileName))
            {
                context.Response.AppendHeader("Content-Type", "application/octet-stream");
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + context.Server.UrlEncode(Path.GetFileName(fileName)));
                context.Response.WriteFile(fileName, false);
            }
            else
            {
                context.Response.Status = "404 File Not Found";
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "File Not Found";
                context.Response.Write("File Not Found");
            }
        }

        public bool IsReusable
        {
            get{ return true; }
        }
    }
}
