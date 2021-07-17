using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

namespace com.abhishek.saraf.ZombieSurvival
{
    public class FloorDetails : MonoBehaviour
    {
        // Awake is called when the script instance is being loaded
        void Awake()
        {
            SetupFloor();
        }

        public void SetupFloor()
        {
            StartCoroutine(RequestWebService());
        }

        IEnumerator RequestWebService()
        {
            string getDataUrl = "https://api.jsonbin.io/b/60f278aac1256a01cb712293";
            // print(getDataUrl);

            using (UnityWebRequest webData = UnityWebRequest.Get(getDataUrl))
            {

                yield return webData.SendWebRequest();
                if (webData.isNetworkError || webData.isHttpError)
                {
                    print("---------------- ERROR ----------------");
                    print(webData.error);
                }
                else
                {
                    if (webData.isDone)
                    {
                        JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data));

                        if (jsonData == null)
                        {
                            print("---------------- NO DATA ----------------");
                        }
                        else
                        {
                            // print("---------------- JSON DATA ----------------");
                            // print("jsonData.Count:" + jsonData.Count);

                            JSONNode jsonNode = jsonData["room_details"];

                            // print(jsonNode);

                            float floorLength = 1.0f, floorWidth = 1.0f;

                            if (jsonNode.HasKey("length"))
                            {
                                floorLength = jsonNode.GetValueOrDefault("length", 1.0f);
                            }

                            if (jsonNode.HasKey("width")) {
                                floorWidth = jsonNode.GetValueOrDefault("width", 1.0f);
                            }

                            transform.localScale = new Vector3(floorLength, 1.0f, floorWidth);
                        }
                    }
                }
            }
        }
    }
}
