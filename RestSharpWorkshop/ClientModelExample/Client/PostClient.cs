using RestSharp;
using RestSharpWorkshop.ClientModelExample.Models;
using System;

namespace RestSharpWorkshop.ClientModelExample.Client
{
    public class PostClient
    {
        private readonly RestClient restClient;

        public PostClient(Uri baseUri)
        {
            restClient = new RestClient(baseUri);
        }

        public RestResponse CreatePost(Post post)
        {
            RestRequest request = new RestRequest("/posts", Method.Post);

            request.AddJsonBody(post);

            return restClient.ExecuteAsync(request).Result;
        }

        public RestResponse GetPost(string postId)
        {
            RestRequest request = new RestRequest($"/posts/{postId}", Method.Get);

            return restClient.ExecuteAsync(request).Result;
        }
    }
}
