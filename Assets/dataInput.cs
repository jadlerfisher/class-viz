using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

public class dataInput : MonoBehaviour
{

    public chicagoData[] myChicagoData;
    public dataVisualization visualization;

    public List<chicagoData> giftList = new List<chicagoData>();



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetChicagoData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Let's grab that data
    IEnumerator GetChicagoData()
    {
        UnityWebRequest www = new UnityWebRequest("data.cityofchicago.org/resource/5d79-9xqr.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            Debug.Log(jsonResult);

            //  // Now put the JSON in an array
            myChicagoData = JsonHelper.getJsonArray<chicagoData>(jsonResult);
            visualization.visualizeIt();
        }
        
    }

   

}
