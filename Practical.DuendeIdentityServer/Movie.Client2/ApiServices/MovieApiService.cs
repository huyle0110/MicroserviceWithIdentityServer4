﻿using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.Client2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using IdentityModel.Client;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<Movies.Client2.Models.Movie>> GetMovies()
        {
            // WAY 1 :
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/movies");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Movies.Client2.Models.Movie>>(content);

            //// WAY 2 :

            //// 1. "retrieve" our api credentials. This must be registered on Identity Server!
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",
            //    ClientId = "movieClient",
            //    ClientSecret = "secret",

            //    // This is the scope our Protected API requires. 
            //    Scope = "movieAPI"
            //};

            // creates a new HttpClient to talk to our IdentityServer (localhost:5005)
            //var client = new HttpClient();

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if (tokenResponse.IsError)
            //{
            //    return null;
            //}

            //var apiClient = new HttpClient();

            //client.SetBearerToken(tokenResponse.AccessToken);

            ////// 4. Send a request to our Protected API
            //var response = await client.GetAsync("https://localhost:5001/api/movies");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            //return movieList;
        }

        public Task<Movies.Client2.Models.Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movies.Client2.Models.Movie> CreateMovie(Movies.Client2.Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movies.Client2.Models.Movie> UpdateMovie(Movies.Client2.Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {           
            var idpClient = _httpClientFactory.CreateClient("IDPClient");
            throw new NotImplementedException();

            //var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            //if (metaDataResponse.IsError)
            //{
            //    throw new HttpRequestException("Something went wrong while requesting the access token");
            //}

            //var accessToken = await _httpContextAccessor
            //    .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            
            //var userInfoResponse = await idpClient.GetUserInfoAsync(
            //   new UserInfoRequest
            //   {
            //       Address = metaDataResponse.UserInfoEndpoint,
            //       Token = accessToken
            //   });

            //if (userInfoResponse.IsError)
            //{
            //    throw new HttpRequestException("Something went wrong while getting user info");
            //}
            
            //var userInfoDictionary = new Dictionary<string, string>();

            //foreach (var claim in userInfoResponse.Claims)
            //{
            //    userInfoDictionary.Add(claim.Type, claim.Value);
            //}

            //return new UserInfoViewModel(userInfoDictionary);
        }
    }
}
