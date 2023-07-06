using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace backend
{
    public class CustomHttpResponse : HttpResponse
    {
        private readonly HttpResponse _httpResponse;

        public CustomHttpResponse(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public override void OnStarting(Func<object, Task> callback, object state)
        {
            _httpResponse.OnStarting(callback, state);
        }

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
            _httpResponse.OnCompleted(callback, state);
        }

        public override void Redirect(string location, bool permanent)
        {
            _httpResponse.Redirect(location, permanent);
        }

        public override HttpContext HttpContext => _httpResponse.HttpContext;

        public override int StatusCode
        {
            get => _httpResponse.StatusCode;
            set => _httpResponse.StatusCode = value;
        }

        public override IHeaderDictionary Headers => _httpResponse.Headers;

        public override Stream Body
        {
            get => _httpResponse.Body;
            set => _httpResponse.Body = value;
        }
        public override long? ContentLength { get => _httpResponse.ContentLength; set => _httpResponse.ContentLength = value; }
        public override string? ContentType { get => _httpResponse.ContentType; set => _httpResponse.ContentType = value; }

        public override IResponseCookies Cookies => _httpResponse.Cookies;

        public override bool HasStarted => _httpResponse.HasStarted;

        public async void SetBody<T>(T content, Encoding encoding = null, string contentType = null)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            var jsonContent = JsonSerializer.Serialize(content, options);
            var bytes = encoding != null ? encoding.GetBytes(jsonContent) : Encoding.UTF8.GetBytes(jsonContent);
            
            _httpResponse.ContentType = contentType ?? "application/json";
            _httpResponse.StatusCode = StatusCodes.Status201Created;
            await _httpResponse.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
