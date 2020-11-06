using Esendex.TokenBucket;
using Org.Openaq.Ap.Openaq.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using victorian_plumbing_technical_test.OpenAqWrapper;

namespace victorian_plumbing_technical_test
{
    class OpenAQClient
    {
        private static OpenAQClient instance = null;
        private static readonly object padlock = new object();

        private ITokenBucket rateLimitBucket;

        private const int requestsPerMin = 2000;

        public static OpenAQClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OpenAQClient();
                    }
                }

                return instance;
            }
        }

        private OpenAQClient()
        {
            rateLimitBucket = TokenBuckets.Construct()
                .WithCapacity(requestsPerMin / 60)
                .WithFixedIntervalRefillStrategy(requestsPerMin / 60, TimeSpan.FromSeconds(1))
                .Build();
        }

        public async Task<List<ICountry>> GetCountriesAsync()
        {
            return await GetAllWithoutPagingAsync(new WrappedCountriesApi());
        }

        public async Task<List<ILocation>> GetLocationsAsync()
        {
            return await GetAllWithoutPagingAsync(new WrappedLocationsApi());
        }

        private async Task<List<T>> GetAllWithoutPagingAsync<T>(IWrappedApi<T> api)
        {
            int? lastRead = 0;
            int page = 1;
            int? count;

            List<T> results = new List<T>();

            do
            {
                var response = await GetAndRateLimit(api, page);
                results.AddRange(response.Results);
                lastRead += response.Metadata.Limit;
                page++;
                count = response.Metadata.Found;
            } while (lastRead != null && count != null && lastRead < count);

            return results;
        }

        private async Task<IOpenAqResponse<T>> GetAndRateLimit<T>(IWrappedApi<T> api, int? page = null)
        {
            await Task.Factory.StartNew(rateLimitBucket.Consume);
            return await api.GetAsync(page: page);
        }
    }
}