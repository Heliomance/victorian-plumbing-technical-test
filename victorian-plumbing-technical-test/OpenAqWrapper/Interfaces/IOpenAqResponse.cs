using Org.Openaq.Ap.Openaq.Interfaces.Models;
using System.Collections.Generic;

namespace victorian_plumbing_technical_test.OpenAqWrapper
{
    interface IOpenAqResponse<T>
    {
        IMeta Metadata { get; set; }

        List<T> Results { get; set; }

    }
}

