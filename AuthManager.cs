using Microsoft.Graph;
using Microsoft.Graph.Authentication;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;
using Azure.Identity;
namespace OneDriveIntegrityTool
{
    public class AuthManager
    {
        private string ClientId, TenantId, ClientSecret;
        public AuthManager(string clientId, string tenantId, string clientSecret)
        {
            ClientId = clientId;
            TenantId = tenantId;
            ClientSecret = clientSecret;
        }

        public GraphServiceClient GetAuthenticatedClient()
        {
            // i want the permissions i set in azure microsoft (file read & file write) for graph api
            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var clientSecretCredential = new ClientSecretCredential(
                TenantId,
                ClientId,
                ClientSecret);

            // construc new graph service client with client secret credential and scopes
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            return graphClient;
        }
    }
}