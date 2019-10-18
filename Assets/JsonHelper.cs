// written by Bekwnn, 2015
// contributed by Guney Ozsan, 2016
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class JsonHelper
{


    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper <T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;

    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    
}