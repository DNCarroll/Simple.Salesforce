using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Simple.Salesforce {
    public class ForceClient : IDisposable
    {
        private readonly ServiceHttpClient _serviceHttpClient;

        public ForceClient(string instanceUrl, string accessToken, string apiVersion, HttpClient httpClient = null)
        {
            if (string.IsNullOrEmpty(instanceUrl)) throw new ArgumentNullException("instanceUrl");
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException("accessToken");
            if (string.IsNullOrEmpty(apiVersion)) throw new ArgumentNullException("apiVersion");

            _serviceHttpClient = new ServiceHttpClient(instanceUrl, apiVersion, accessToken, httpClient);
        }

        public Task<QueryResult<T>> QueryAsync<T>(string query)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException("query");

            return _serviceHttpClient.HttpGetAsync<QueryResult<T>>(string.Format("query?q={0}", Uri.EscapeDataString(query)));
        }

        public Task<QueryResult<T>> QueryContinuationAsync<T>(string nextRecordsUrl)
        {
            if (string.IsNullOrEmpty(nextRecordsUrl)) throw new ArgumentNullException("nextRecordsUrl");

            return _serviceHttpClient.HttpGetAsync<QueryResult<T>>(nextRecordsUrl);
        }                
        
        public async Task<SuccessResponse> CreateAsync(string objectName, object record)
        {
            if (string.IsNullOrEmpty(objectName)) throw new ArgumentNullException("objectName");
            if (record == null) throw new ArgumentNullException("record");

            return await _serviceHttpClient.HttpPostAsync<SuccessResponse>(record, string.Format("sobjects/{0}", objectName)).ConfigureAwait(false);
        }

        public Task<SuccessResponse> UpdateAsync(string objectName, string recordId, object record)
        {
            if (string.IsNullOrEmpty(objectName)) throw new ArgumentNullException("objectName");
            if (string.IsNullOrEmpty(recordId)) throw new ArgumentNullException("recordId");
            if (record == null) throw new ArgumentNullException("record");

            return _serviceHttpClient.HttpPatchAsync(record, string.Format("sobjects/{0}/{1}", objectName, recordId));
        }

        public Task<bool> DeleteAsync(string objectName, string recordId)
        {
            if (string.IsNullOrEmpty(objectName)) throw new ArgumentNullException("objectName");
            if (string.IsNullOrEmpty(recordId)) throw new ArgumentNullException("recordId");

            return _serviceHttpClient.HttpDeleteAsync(string.Format("sobjects/{0}/{1}", objectName, recordId));
        }        

        public void Dispose()
        {
            _serviceHttpClient.Dispose();
        }
    }
}
