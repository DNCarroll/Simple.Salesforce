using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Simple.Salesforce
{
    /// <summary>
    /// Extension methods for <see cref="HttpContent"/>.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Content-Encoding default value 
        /// </summary>
        public const string GZipEncoding = "gzip";

        /// <summary>
        /// Returns the response content to string. It decompresses the content if needed
        /// </summary>
        /// <param name="responseContent">Http Response Message</param>
        /// <returns>Http Response content as string</returns>
        public static async Task<string> ReadAsDecompressedStringAsync(this HttpContent responseContent)
        {
            string content;

            if (responseContent == null)
            {
                return string.Empty;
            }

            // Check if the response content is gzip encoded. Gzipped response length is less than the actual and thereby less 
            // payload over the network.
            if (responseContent.Headers.ContentEncoding.Contains(GZipEncoding,StringComparer.OrdinalIgnoreCase))
            {
                var responseStream = await responseContent.ReadAsStreamAsync().ConfigureAwait(false);
                var unzippedContent = new GZipStream(responseStream, CompressionMode.Decompress);
                content = await(new StreamReader(unzippedContent)).ReadToEndAsync();
            }
            else
            {
                content = await responseContent.ReadAsStringAsync().ConfigureAwait(false);
            }

            return content;
        }

        public async static Task<List<T>> GetObjects<T>(this string queryString, ForceClient client = null)
            where T : class, new() {
            if (client == null) {
                using (client = await Common.ForceClient()) {
                    var objs = await client.QueryAsync<T>(queryString);
                    return objs.Records;
                }
            }
            else {
                var objs = await client.QueryAsync<T>(queryString);
                return objs.Records;
            }
        }

        public async static Task<T> FirstOrDefault<T>(this string queryString, ForceClient client = null, Func<T, bool> filter = null)
            where T : class, new() {
            var result = await queryString.GetObjects<T>(client);
            if (result.Count > 0) {
                return filter != null ? result.FirstOrDefault(filter) : result.FirstOrDefault();
            }
            return null;
        }

        public async static Task<SuccessResponse> Create(this string objectName, object recordToInsert, ForceClient client = null) {
            SuccessResponse response = null;
            try {
                if (client == null) {
                    using (client = await Common.ForceClient()) {
                        response = await client.CreateAsync(objectName, recordToInsert);
                    }
                }
                else {
                    response = await client.CreateAsync(objectName, recordToInsert);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return response;
        }

        static string getIdFromObject(object obj) {
            string id = null;
            var prop = obj.GetType().GetProperty("Id");
            if (prop != null) {
                id = (string)prop.GetValue(obj);             
            }
            return id;
        }


        public async static Task<SuccessResponse> Update(this string objectName, object recordToUpdate, ForceClient client = null) {
            string id = getIdFromObject(recordToUpdate);
            if (id != null) {
                return await objectName.Update(id, recordToUpdate, client);
            }
            throw new Exception("Could not find Id on the given object");
        }

        public async static Task<SuccessResponse> Update(this string objectName, string id, object recordToUpdate, ForceClient client = null) {
            SuccessResponse response = null;
            try {
                if (client == null) {
                    using (client = await Common.ForceClient()) {
                        response = await client.UpdateAsync(objectName, id, recordToUpdate);
                    }
                }
                else {
                    response = await client.UpdateAsync(objectName, id, recordToUpdate);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return response;
        }

        public async static Task<bool> Delete(this string objectName, object objectToDelete, ForceClient client = null) {
            var response = false;
            var id = getIdFromObject(objectToDelete);
            if (id != null) {
                response = await objectName.Delete(id, client);
            }
            return response;
        }

        public async static Task<bool> Delete(this string objectName, string idToDelete, ForceClient client = null) {
            var response = false;
            try {
                if (client == null) {
                    using (client = await Common.ForceClient()) {
                        response = await client.DeleteAsync(objectName, idToDelete);
                    }
                }
                else {
                    response = await client.DeleteAsync(objectName, idToDelete);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return response;
        }

    }
}
