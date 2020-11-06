using Org.Openaq.Ap.Openaq.Interfaces.Models;
using Org.Openaq.Api.Openaq.Api;
using Org.Openaq.Api.Openaq.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace victorian_plumbing_technical_test.OpenAqWrapper
{
    class WrappedLocationsApi : IWrappedApi<ILocation>
    {
        private ILocationsApi locationsApi;

        public WrappedLocationsApi()
        {
            locationsApi = new LocationsApi();
        }

        public IOpenAqResponse<ILocation> Get(List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response = locationsApi.GetLocations(orderBy: orderBy, sort: sort, limit: limit, page: page);
            return new OpenAqResponse<ILocation> {Metadata = response.Metadata, Results = response.Results};
        }

        public async Task<IOpenAqResponse<ILocation>> GetAsync(List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            // BUG: This line is throwing an error inside the library and I can't work out why in the time available
            var response = await locationsApi.GetLocationsAsync(orderBy: orderBy, sort: sort, limit: limit, page: page);
            return new OpenAqResponse<ILocation> {Metadata = response.Metadata, Results = response.Results};
        }

        public async Task<ApiResponse<IOpenAqResponse<ILocation>>> GetAsyncWithHttpInfo(List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response =
                await locationsApi.GetLocationsAsyncWithHttpInfo(orderBy: orderBy,
                    sort: sort,
                    limit: limit,
                    page: page);
            return new ApiResponse<IOpenAqResponse<ILocation>>(response.StatusCode,
                response.Headers,
                new OpenAqResponse<ILocation> {Metadata = response.Data.Metadata, Results = response.Data.Results});
        }

        public ApiResponse<IOpenAqResponse<ILocation>> GetWithHttpInfo(List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null)
        {
            var response =
                locationsApi.GetLocationsWithHttpInfo(orderBy: orderBy, sort: sort, limit: limit, page: page);
            return new ApiResponse<IOpenAqResponse<ILocation>>(response.StatusCode,
                response.Headers,
                new OpenAqResponse<ILocation> {Metadata = response.Data.Metadata, Results = response.Data.Results});
        }
    }
}