using Org.Openaq.Ap.Openaq.Interfaces.Models;
using Org.Openaq.Api.Openaq.Api;
using Org.Openaq.Api.Openaq.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace victorian_plumbing_technical_test.OpenAqWrapper
{
    class WrappedCountriesApi : IWrappedApi<ICountry>
    {
        private ICountriesApi countriesApi;

        public WrappedCountriesApi()
        {
            countriesApi = new CountriesApi();
        }


        public IOpenAqResponse<ICountry> Get(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response = countriesApi.GetCountries(orderBy, sort, limit, page);
            return new OpenAqResponse<ICountry> {Metadata = response.Metadata, Results = response.Results};
        }

        public ApiResponse<IOpenAqResponse<ICountry>> GetWithHttpInfo(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response = countriesApi.GetCountriesWithHttpInfo(orderBy, sort, limit, page);
            return new ApiResponse<IOpenAqResponse<ICountry>>(response.StatusCode,
                response.Headers,
                new OpenAqResponse<ICountry> {Metadata = response.Data.Metadata, Results = response.Data.Results});
        }

        public async Task<IOpenAqResponse<ICountry>> GetAsync(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response = await countriesApi.GetCountriesAsync(orderBy: orderBy, sort: sort, limit: limit, page: page);
            return new OpenAqResponse<ICountry> {Metadata = response.Metadata, Results = response.Results};
        }

        public async Task<ApiResponse<IOpenAqResponse<ICountry>>> GetAsyncWithHttpInfo(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response = await countriesApi.GetCountriesAsyncWithHttpInfo(orderBy, sort, limit, page);
            return new ApiResponse<IOpenAqResponse<ICountry>>(response.StatusCode,
                response.Headers,
                new OpenAqResponse<ICountry> {Metadata = response.Data.Metadata, Results = response.Data.Results});
        }
    }
}