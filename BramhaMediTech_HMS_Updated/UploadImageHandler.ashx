<%@ WebHandler Language="C#" Class="UploadImageHandler" %>

using System;
using System.IO;
using System.Web;

public class UploadImageHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        // Retrieve image data from request
        string imageData = context.Request.Form["imageData"];

        // Decode base64 image data
        byte[] imageBytes = Convert.FromBase64String(imageData.Split(',')[1]);

        // Save image to the server (you can customize the path)
        string imagePath = context.Server.MapPath("~/CapturedImages/");
        string imageName = "captured_image_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string imageFilePath = Path.Combine(imagePath, imageName);
        File.WriteAllBytes(imageFilePath, imageBytes);

        // Respond with success status
        context.Response.ContentType = "text/plain";
        context.Response.Write("Image uploaded successfully.");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}