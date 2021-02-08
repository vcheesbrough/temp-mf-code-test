using SlothEnterprise.External;

namespace SlothEnterprise.ProductApplication
{
    public static class ApplicationResultExtensions
    {
        public static int AsApplicationId(this IApplicationResult result)
        {
            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}