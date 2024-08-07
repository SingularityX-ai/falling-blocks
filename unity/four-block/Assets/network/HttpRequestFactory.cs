using System;
using System.Net.Http;

namespace network
{
    public class HttpRequestFactory
    {

        /// <summary>
        /// Creates an HTTP request based on the specified request type.
        /// </summary>
        /// <param name="requestType">The HTTP method to be used for the request, such as GET or POST.</param>
        /// <returns>An instance of <see cref="IHttpRequest"/> corresponding to the specified request type.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided <paramref name="requestType"/> is not supported.</exception>
        /// <remarks>
        /// This method is responsible for generating different types of HTTP requests based on the provided
        /// <paramref name="requestType"/>. If the request type is HttpMethod.Get, it creates an instance of
        /// <see cref="HttpGetRequest"/>. If the request type is HttpMethod.Post, it creates an instance of
        /// <see cref="HttpPostRequest"/>. If the request type does not match any supported methods, an
        /// <see cref="ArgumentException"/> is thrown indicating that the request type is invalid. This allows
        /// for flexible handling of various HTTP methods in a clean and organized manner.
        /// </remarks>
        public IHttpRequest CreateHttpRequest(HttpMethod requestType)
        {
            if (requestType == HttpMethod.Get)
            {
                return new HttpGetRequest();
            }
            else if (requestType == HttpMethod.Post)
            {
                return new HttpPostRequest();
            }
            else
            {
                throw new ArgumentException("Invalid request type");
            }
        }
    }
}