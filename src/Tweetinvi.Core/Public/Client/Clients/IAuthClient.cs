using System;
using System.Threading.Tasks;
using Tweetinvi.Core.Client.Validators;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Tweetinvi.Client
{
    public interface IAuthClient
    {
        /// <summary>
        /// Validate all the Account activity client parameters
        /// </summary>
        IAuthClientParametersValidator ParametersValidator { get; }

        /// <inheritdoc cref="IAuthClient.CreateBearerTokenAsync(ICreateBearerTokenParameters)"/>
        Task<string> CreateBearerTokenAsync();

        /// <summary>
        /// Allows a registered application to obtain an OAuth 2 Bearer Token.
        /// Bearer token allows to make API requests on an application's own behalf, without a user context.
        /// This is called Application-only authentication.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The bearer token to use for application only authentication</returns>
        Task<string> CreateBearerTokenAsync(ICreateBearerTokenParameters parameters);

        /// <summary>
        /// Gets the bearer token generated by <see cref="CreateBearerTokenAsync()"/> and updates the client's current credentials.
        /// To learn more about bearer token read <see cref="CreateBearerTokenAsync()"/>.
        /// </summary>
        /// <para>
        /// IMPORTANT NOTE: The setter is for convenience. It is strongly recommended to create a new TwitterClient instead.
        /// As using this setter could result in unexpected concurrency between the time of set and the execution of previous
        /// non awaited async operations.
        /// </para>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        Task InitializeClientBearerTokenAsync();

        /// <summary>
        /// Initiates a pin based authentication process for a user.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token </para>
        /// <returns>An AuthenticationRequest containing the url to redirect the user</returns>
        Task<IAuthenticationRequest> RequestAuthenticationUrlAsync();

        /// <inheritdoc cref="IAuthClient.RequestAuthenticationUrlAsync(IRequestAuthUrlParameters)" />
        Task<IAuthenticationRequest> RequestAuthenticationUrlAsync(string callbackUrl);

        /// <inheritdoc cref="IAuthClient.RequestAuthenticationUrlAsync(IRequestAuthUrlParameters)" />
        Task<IAuthenticationRequest> RequestAuthenticationUrlAsync(Uri callbackUri);

        /// <summary>
        /// Initiates the authentication process for a user.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/request_token </para>
        /// <returns>An AuthenticationRequest containing the url to redirect the user</returns>
        Task<IAuthenticationRequest> RequestAuthenticationUrlAsync(IRequestAuthUrlParameters parameters);

        /// <inheritdoc cref="IAuthClient.RequestCredentialsAsync(IRequestCredentialsParameters)"/>
        Task<ITwitterCredentials> RequestCredentialsFromVerifierCodeAsync(string verifierCode, IAuthenticationRequest authenticationRequest);

        /// <summary>
        /// Request credentials with a verifierCode
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The requested user credentials</returns>
        Task<ITwitterCredentials> RequestCredentialsAsync(IRequestCredentialsParameters parameters);

        /// <inheritdoc cref="IAuthClient.RequestCredentialsFromCallbackUrlAsync(Uri, IAuthenticationRequest)"/>
        Task<ITwitterCredentials> RequestCredentialsFromCallbackUrlAsync(string callbackUrl, IAuthenticationRequest authenticationRequest);

        /// <summary>
        /// Request credentials from an AuthenticationRequest.
        /// This is assuming that the callback url contains the expected parameter,
        /// and that the AuthenticationTokenProvider has access to the returned token id.
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/token </para>
        /// <returns>The requested user credentials</returns>
        Task<ITwitterCredentials> RequestCredentialsFromCallbackUrlAsync(Uri callbackUri, IAuthenticationRequest authenticationRequest);

        /// <inheritdoc cref="IAuthClient.InvalidateBearerTokenAsync(IInvalidateBearerTokenParameters)"/>
        Task<InvalidateTokenResponse> InvalidateBearerTokenAsync();

        /// <summary>
        /// Invalidates a BearerToken
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/invalidate_bearer_token </para>
        Task<InvalidateTokenResponse> InvalidateBearerTokenAsync(IInvalidateBearerTokenParameters parameters);

        /// <inheritdoc cref="IAuthClient.InvalidateAccessTokenAsync(IInvalidateAccessTokenParameters)" />
        Task<InvalidateTokenResponse> InvalidateAccessTokenAsync();

        /// <summary>
        /// Invalidate an AccessToken
        /// </summary>
        /// <para> https://developer.twitter.com/en/docs/basics/authentication/api-reference/invalidate_access_token </para>
        Task<InvalidateTokenResponse> InvalidateAccessTokenAsync(IInvalidateAccessTokenParameters parameters);
    }
}