using Org.Openaq.Ap.Openaq.Interfaces.Models;
using System.Collections.Generic;

namespace victorian_plumbing_technical_test.OpenAqWrapper
{
    class OpenAqResponse<T>: IOpenAqResponse<T>
    {
        public IMeta Metadata { get; set; }
        public List<T> Results { get; set; }

    }
}
