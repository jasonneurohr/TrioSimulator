using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrioSimulator
{
    public class AdjustHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public AdjustHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Match the Headers sent by a real Polycom Trio
            httpContext.Response.Headers.Append("Server", "Polycom SoundPoint IP Telephone HTTPd");
            httpContext.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
            httpContext.Response.Headers.Append("Cache-Control", "no-store");

            httpContext.Response.OnStarting((state) =>
            {
                if (httpContext.Response.Headers.Count > 0 && httpContext.Response.Headers.ContainsKey("Content-Type"))
                {
                    var contentType = httpContext.Response.Headers["Content-Type"].ToString();
                    if (contentType.StartsWith("application/json"))
                    {
                        // To strip of the encoding
                        // without = Content-type application/json; charset=utf-8
                        // with = Content-type: application/json
                        httpContext.Response.Headers.Remove("Content-Type");
                        httpContext.Response.Headers.Append("Content-type", "application/json");
                    }
                }

                // To dump the request and response headers to console
                //                foreach (var value in httpContext.Request.Headers)
                //                {
                //                    Console.WriteLine("REQUEST: " + value.Key + ": " + value.Value);
                //                }
                //
                //                foreach (var value in httpContext.Response.Headers)
                //                {
                //                    Console.WriteLine("RESPONSE: " + value.Key + ": " + value.Value);
                //                }

                if (httpContext.Response.StatusCode == 401)
                {
                    // Pseudo BASIC authentication
                    httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"API Authentication\"");
                    var msg = "<!DOCTYPE HTML PUBLIC \" -//IETF//DTD HTML 2.0//EN\">\n<html><head><title>401 Unauthorized</title></head><body>\nAuthorization failed.\n</body></html>";

                    httpContext.Response.WriteAsync(msg);
                }

                return Task.FromResult(0);
            }, null);

            await _next.Invoke(httpContext);
        }
    }
}
