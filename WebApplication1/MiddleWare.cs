using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MiddleWare
    {
        private readonly RequestDelegate _next;
        private static int logNumber=1;
        public MiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                var response = await FormatResponse(context.Response);
                File.AppendAllText(@"C:\Users\smishra\source\repos\WebApplication1\WebApplication1\Log\Log.txt",request);
                File.AppendAllText(@"C:\Users\smishra\source\repos\WebApplication1\WebApplication1\Log\Log.txt",response);
                logNumber++;
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableRewind();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            var bodyAsText = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;
            return $"[Log Id = {logNumber}]\nREQUEST : \n\t{request.Path.Value}  {request.Method} {bodyAsText}{Environment.NewLine}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"RESPONSE : \n  Status: {response.StatusCode} \n  Message: {text}{Environment.NewLine}{Environment.NewLine}";
        }
    }
}
