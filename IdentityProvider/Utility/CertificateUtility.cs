
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace IdentityProvider.Utility
{
    public static class CertificateUtility
    {
        public static X509Certificate2 GetCert(StoreName name, StoreLocation location, string subject)
        {
            X509Certificate2Collection certificates = null;
            var store = new X509Store(name, location);
            store.Open(OpenFlags.ReadOnly);

            try
            {
                certificates = store.Certificates;

                foreach (var certificate in certificates.Cast<X509Certificate2>().Where(certificate => certificate.SubjectName.Name == subject))
                {
                    return new X509Certificate2(certificate);
                }
            }
            finally
            {
                if (certificates != null)
                {
                    foreach (var certificate in certificates)
                    {
                        certificate.Reset();
                    }

                    store.Close();
                }
            }

            return null;
        }
    }
}