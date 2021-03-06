using System.Threading.Tasks;
using Tweetinvi.Iterators;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters.V2;

namespace Tweetinvi.Client.V2
{
    public interface ISearchV2Client
    {
        /// <inheritdoc cref="GetSearchTweetsV2Iterator(ISearchTweetsV2Parameters)"/>
        Task<SearchTweetsV2Response> SearchTweetsAsync(string query);

        /// <summary>
        /// Search for tweets
        /// </summary>
        /// <para> Read more : https://developer.twitter.com/en/docs/twitter-api/tweets/search/api-reference/get-tweets-search-recent </para>
        /// <returns>First page of search results</returns>
        Task<SearchTweetsV2Response> SearchTweetsAsync(ISearchTweetsV2Parameters parameters);

        /// <inheritdoc cref="GetSearchTweetsV2Iterator(ISearchTweetsV2Parameters)"/>
        ITwitterRequestIterator<SearchTweetsV2Response, string> GetSearchTweetsV2Iterator(string query);

        /// <summary>
        /// Search for tweets
        /// </summary>
        /// <para> Read more : https://developer.twitter.com/en/docs/twitter-api/tweets/search/api-reference/get-tweets-search-recent </para>
        /// <returns>Iterator over the search results</returns>
        ITwitterRequestIterator<SearchTweetsV2Response, string> GetSearchTweetsV2Iterator(ISearchTweetsV2Parameters parameters);
    }
}