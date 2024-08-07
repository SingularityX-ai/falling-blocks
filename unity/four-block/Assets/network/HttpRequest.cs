using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace network
{
    public class HttpGetRequest : IHttpRequest
    {
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Asynchronously sends a POST request to the specified URL with JSON content and returns the response body as a string.
        /// </summary>
        /// <param name="url">The URL to which the POST request is sent.</param>
        /// <returns>A task that represents the asynchronous operation, containing the response body as a string.</returns>
        /// <remarks>
        /// This method creates a new instance of <see cref="StringContent"/> with the provided data encoded in UTF-8 and sets the media type to "application/json".
        /// It then sends an asynchronous POST request using the <see cref="_client"/> instance.
        /// If the response indicates a failure (i.e., a non-success status code), an exception is thrown by calling <see cref="EnsureSuccessStatusCode"/>.
        /// Upon successful completion, the method reads the response content as a string and returns it.
        /// This allows for easy handling of HTTP responses in applications that require interaction with web services.
        /// </remarks>
        public async Task<string> ExecuteAsync(string url)
        {
            HttpResponseMessage response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
    
    public class HttpPostRequest : IHttpRequest
    {
        private HttpClient _client = new HttpClient();
        private string _data = "";

        public async Task<string> ExecuteAsync(string url)
        {
            var content = new StringContent(_data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        /// <summary>
        /// Sets the data for the HTTP POST request.
        /// </summary>
        /// <param name="data">The data to be set for the request.</param>
        /// <returns>The current instance of <see cref="HttpPostRequest"/> with the updated data.</returns>
        /// <remarks>
        /// This method assigns the provided <paramref name="data"/> to the private field <c>_data</c> of the
        /// <see cref="HttpPostRequest"/> class. It returns the same instance of the class, allowing for
        /// method chaining. This is useful when configuring multiple properties of the request in a fluent style.
        /// The method does not perform any validation on the input data, so it is assumed that the caller
        /// will provide valid data for the request.
        /// </remarks>
        public HttpPostRequest SetData(string data)
        {
            this._data = data;
            return this;
        }

        /// <summary>
        /// Sets the HttpClient instance for the current request.
        /// </summary>
        /// <param name="client">The HttpClient instance to be set.</param>
        /// <returns>The current instance of HttpPostRequest for method chaining.</returns>
        /// <remarks>
        /// This method assigns the provided HttpClient instance to the private field <c>_client</c> of the HttpPostRequest class.
        /// It allows for configuring the request with a specific HttpClient, which can be useful for setting up custom headers,
        /// handling timeouts, or managing connection settings. By returning the current instance of HttpPostRequest,
        /// this method supports a fluent interface, enabling multiple method calls to be chained together in a single statement.
        /// </remarks>
        public HttpPostRequest SetClient(HttpClient client)
        {
            this._client = client;
            return this;
        }
    }
}