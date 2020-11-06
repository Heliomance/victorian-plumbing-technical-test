using Org.Openaq.Api.Openaq.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace victorian_plumbing_technical_test.OpenAqWrapper
{
    interface IWrappedApi<T>
    {
        IOpenAqResponse<T> Get(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null);

        ApiResponse<IOpenAqResponse<T>> GetWithHttpInfo(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null);

        Task<IOpenAqResponse<T>> GetAsync(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null);

        Task<ApiResponse<IOpenAqResponse<T>>> GetAsyncWithHttpInfo(
            List<string> orderBy = null,
            List<string> sort = null,
            int? limit = null,
            int? page = null);
    }
}