using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// 需客制化實作 IController
/// </summary>
namespace SimsBackendRelay.BackendSwag
{
    public class ControllerImp : IController, IDisposable
    {
        private ILogger<ControllerImp> _logger;
        private Client _client = null;
        private System.Net.Http.HttpClient _httpClient = null;

        public ControllerImp(ILogger<ControllerImp> logger)
        {
            _logger = logger;
            _httpClient = new System.Net.Http.HttpClient();
            _client = new Client(@"http://localhost:50731/", _httpClient);
        }

        #region Dispose
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing)
                {
                    //# dispose resource
                    if (_httpClient != null)
                        _httpClient.Dispose();
                }

                // Indicate that the instance has been disposed.
                _client = null;
                _httpClient = null;
                _disposed = true;
            }
        }

        #endregion

        Task<ICollection<FormInfo>> IController.QueryFormAsync()
        {
            return _client.TestformQueryformAsync();
        }

        Task<FormInfo> IController.LoadFormAsync(string formNo)
        {
            return _client.TestformLoadformAsync(formNo);
        }

        Task<FormInfo> IController.SaveFormAsync(FormInfo body)
        {
            return _client.TestformSaveformAsync(body);
        }

        Task<ErrMsg> IController.LongTimeCalcAsync(int? spend)
        {
            return _client.TestformLongtimecalcAsync(spend);
        }
    }
}
