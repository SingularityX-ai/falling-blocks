using System.Net.Http;
using UnityEngine;

namespace network.user
{
    public class UserService
    {

        /// <summary>
        /// Retrieves the username from a remote API endpoint.
        /// </summary>
        /// <returns>A string representing the username retrieved from the API.</returns>
        /// <remarks>
        /// This method creates an HTTP GET request to the specified API endpoint to fetch the username associated with a user ID.
        /// It uses an instance of <see cref="HttpRequestFactory"/> to create the request and executes it asynchronously.
        /// The method waits for the response to complete before logging the result and returning the username as a string.
        /// Note that this method blocks the calling thread until the asynchronous operation is complete, which may lead to performance issues in a UI context.
        /// </remarks>
        public string GetUserName()
        {
            var httpRequestFactory = new HttpRequestFactory();
            var getRequest = (HttpGetRequest)httpRequestFactory.CreateHttpRequest(HttpMethod.Get);
            var getResponse = getRequest.ExecuteAsync("https://liamlime.com/api/user/username/1");
            getResponse.Wait();
            var result = getResponse.Result;
            Debug.Log(result);
            return result;
        }
    }
}