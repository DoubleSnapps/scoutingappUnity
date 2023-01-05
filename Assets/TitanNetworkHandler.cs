using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class TitanNetworkHandler : MonoBehaviour
{
    public static TitanNetworkHandler instance;

    public class TitanNetworkRequest
    {
        public enum RequestStatus
        {
            PENDING,
            IN_PROGRESS,
            SUCCESS,
            FAILURE,
            I_QUIT
        }
        public RequestStatus status;
        public string endpoint;
        public enum Method
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public Method method;

        public string result;
        public Action<string, TitanNetworkRequest> callback;
        public string callbackData;

        public TitanNetworkRequest(string endpoint)
        {
            this.endpoint = endpoint;
        }
        int attempts = 0;
        public string data;
        public IEnumerator post(string data)
        {
            this.data = data;
            attempts++;
            if (attempts > 3) {
                this.status = RequestStatus.I_QUIT;
                yield break;
            }
            this.method = Method.POST;
            this.status = RequestStatus.IN_PROGRESS;
            WWWForm form = new WWWForm();

            form.AddField("data", data);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:1337/api/v1/" + endpoint, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                    //log full resposne
                    Debug.Log(www.downloadHandler.text);
                    this.status = RequestStatus.FAILURE;
                }
                else
                {
                    Debug.Log("success");
                    this.status = RequestStatus.SUCCESS;
                    this.result = www.responseCode.ToString();
                }
            }
        }
    }

    public List<TitanNetworkRequest> requests = new List<TitanNetworkRequest>();

    public void Update() {
        List<TitanNetworkRequest> toRemove = new List<TitanNetworkRequest>();
        foreach (TitanNetworkRequest request in requests) {
            if (request.status == TitanNetworkRequest.RequestStatus.SUCCESS) {
                request.callback(request.result, request);
                Debug.Log("calling callback");
                toRemove.Add(request);
            }
            //handle failure
            if(request.status == TitanNetworkRequest.RequestStatus.FAILURE) {
                StartCoroutine(request.post(request.data));
            }
            //handle quitting
            if(request.status == TitanNetworkRequest.RequestStatus.I_QUIT) {
                toRemove.Add(request);
            }
        }
        foreach (TitanNetworkRequest request in toRemove) {
            requests.Remove(request);
        }
    }

    private void Start() {
        instance = this;
    }
}
