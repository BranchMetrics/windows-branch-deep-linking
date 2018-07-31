﻿using BranchSdk.Net.Requests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BranchSdk.Net {
    public static class BranchServerRequestQueue {
        public static int MaxRequestsAtOnce = 25;

        private static List<BranchServerRequest> queue = new List<BranchServerRequest>();
        private static Queue<BranchServerRequest> runningQueue = new Queue<BranchServerRequest>();

        public static void AddRequest(BranchServerRequest request) {
            queue.Add(request);
        }

        public static bool RunQueue() {
            if (runningQueue.Count > 0) return false;

            for (int i = 0; i < queue.Count && i < MaxRequestsAtOnce; i++) {
                runningQueue.Enqueue(queue[i]);
            }

            queue.RemoveRange(0, runningQueue.Count);

            Task.Run(() => { TaskWorkingAsync(); });
            return true;
        }

        private static async void TaskWorkingAsync() {
            while (runningQueue.Count > 0) {
                BranchServerRequest request = runningQueue.Dequeue();

                try {
                    HttpClient httpClient = new HttpClient();
                    var headers = httpClient.DefaultRequestHeaders;

                    if (request.RequestType == RequestTypes.GET) {
                        Uri requestUri = new Uri(GetUriWithParameters(request.RequestUrl(), request.Parameters));
                        HttpResponseMessage httpResponse = new HttpResponseMessage();
                        string httpResponseBody = "";

                        httpResponse = await httpClient.GetAsync(requestUri);
                        httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                        if (httpResponse.IsSuccessStatusCode) {
                            string responseAsText = await httpResponse.Content.ReadAsStringAsync();
                            request.OnSuccess(responseAsText);
                        } else {
                            string rawError = await httpResponse.Content.ReadAsStringAsync();
                            request.OnFailed(rawError, (int)httpResponse.StatusCode);
                            Debug.WriteLine("Request Error: " + rawError);
                        }
                    } else if (request.RequestType == RequestTypes.POST) {
                        Uri requestUri = new Uri(request.RequestUrl());
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                        HttpContent content = new StringContent(request.PostData.ToString(), Encoding.UTF8, "application/json");
                        HttpResponseMessage httpResponse = await httpClient.PostAsync(requestUri, content);

                        Debug.WriteLine("Post data: " + request.PostData);

                        if (httpResponse.IsSuccessStatusCode) {
                            string responseAsText = await httpResponse.Content.ReadAsStringAsync();
                            request.OnSuccess(responseAsText);
                        } else {
                            string rawError = await httpResponse.Content.ReadAsStringAsync();
                            Debug.WriteLine("Request Error: " + rawError);
                        }
                    }
                } catch (Exception e) {
                    Debug.WriteLine("Error: " + e.Message + " - " + e.StackTrace);
                }
            }
        }

        public static string GetUriWithParameters(string baseUri, Dictionary<string, string> parameters) {
            StringBuilder uriString = new StringBuilder();
            uriString.Append(baseUri);
            uriString.Append("?");
            foreach (string key in parameters.Keys) {
                uriString.Append(string.Format("{0}={1}&", key, parameters[key]));
            }
            uriString.Remove(uriString.Length - 1, 1);
            return uriString.ToString();
        }
    }
}
