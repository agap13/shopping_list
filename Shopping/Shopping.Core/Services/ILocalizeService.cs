// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using System.Globalization;

namespace Shopping.Core.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
