using System.Net.Http;
using UnityEngine;

namespace network.score
{
    public class ScoreService
    {

        /// <summary>
        /// Submits a user's score to a remote server.
        /// </summary>
        /// <param name="score">The score to be submitted.</param>
        /// <remarks>
        /// This method creates an HTTP POST request to submit the provided score to a specified API endpoint.
        /// It utilizes an instance of <see cref="HttpRequestFactory"/> to create the request and sets the score data in JSON format.
        /// The request is executed asynchronously, and upon completion, the result is logged using <see cref="Debug.Log"/>.
        /// This method does not return any value and operates asynchronously, meaning that the calling thread will not be blocked while waiting for the response.
        /// </remarks>
        public void SubmitScore(int score)
        {
            var httpRequestFactory = new HttpRequestFactory();
            var postRequest = (HttpPostRequest)httpRequestFactory.CreateHttpRequest(HttpMethod.Post);
            var postResponse = postRequest
                .SetData("{\"score\": "+score+"}")
                .SetClient(new HttpClient())
                .ExecuteAsync("https://liamlime.com/api/user/score/1");
            postResponse.ContinueWith(task =>
            {
                var result = postResponse.Result;
                Debug.Log(result);
            });
        }
    }
}