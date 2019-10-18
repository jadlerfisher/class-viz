using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dataVisualization : MonoBehaviour
{

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnY = 1;
    public int columnZ = 2;

    // Full column names
    public string xName;
    public string yName;
    public string zName;

    public dataInput dataSource;

    public GameObject PointPrefab;

    public List<chicagoData> chicagoDataList = new List<chicagoData>();

    public GameObject PointHolder;

    float xMax;
    float yMax;
    float zMax;

    // Get minimums of each axis
    float xMin;
    float yMin;
    float zMin;

    public float plotScale = 10;

    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void visualizeIt() {

        chicagoDataList.AddRange(dataSource.myChicagoData);


        //// Get maxes of each axis
        xMax = FindMaxValuePeriodStart();
        yMax = FindMaxValueAmount();
        zMax = FindMaxValuePeriodEnd();

        //// Get minimums of each axis
        xMin = FindMinValuePeriodStart();
        yMin = FindMinValueAmount();
        zMin = FindMinValuePeriodEnd();



        //Loop through chicagoDataList
        for (var i = 0; i < chicagoDataList.Count; i++)
        {

            float x = (System.Convert.ToSingle(chicagoDataList[i].lobbyist_id) - xMin) / (xMax - xMin);

            float y = (System.Convert.ToSingle(chicagoDataList[i].value) - yMin)  / (yMax - yMin);

            float z = (System.Convert.ToSingle(chicagoDataList[i].gift_id) - zMin) / (zMax - zMin);

            GameObject dataPoint = Instantiate(
                                PointPrefab,
                                new Vector3(x, y, z) * plotScale,
                                Quaternion.identity); dataPoint.transform.parent = PointHolder.transform;

            string dataPointName = chicagoDataList[i].lobbyist_firstname + " " + chicagoDataList[i].lobbyist_lastname + " " + chicagoDataList[i].gift;

            //// Assigns name to the prefab
            dataPoint.transform.name = dataPointName;

            ///Give it a color

            dataPoint.GetComponent<Renderer>().material.color =
                new Color(x, y, z, 1.0f);
        }

    }


    private float FindMaxValueAmount()
    {
        //set initial value to first value
        float maxValue = Convert.ToSingle(chicagoDataList[0].value);

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(chicagoDataList[i].value))
                maxValue = Convert.ToSingle(chicagoDataList[i].value);
        }

        //Spit out the max value
        return maxValue;
    }


    private float FindMinValueAmount()
    {

        float minValue = Convert.ToSingle(chicagoDataList[0].value);

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (Convert.ToSingle(chicagoDataList[i].value) < minValue)
                minValue = Convert.ToSingle(chicagoDataList[i].value);
        }

        return minValue;
    }

    private float FindMaxValuePeriodStart()
    {
        //set initial value to first value
        float maxValue = Convert.ToSingle(chicagoDataList[0].lobbyist_id);

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(chicagoDataList[i].lobbyist_id))
                maxValue = Convert.ToSingle(chicagoDataList[i].lobbyist_id);
        }

        //Spit out the max value
        return maxValue;
    }


    private float FindMinValuePeriodStart()
    {

        float minValue = Convert.ToSingle(chicagoDataList[0].lobbyist_id);

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (Convert.ToSingle(chicagoDataList[i].lobbyist_id) < minValue)
                minValue = Convert.ToSingle(chicagoDataList[i].lobbyist_id);
        }

        return minValue;
    }

    private float FindMaxValuePeriodEnd()
    {
        //set initial value to first value
        float maxValue = Convert.ToSingle(chicagoDataList[0].gift_id);

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(chicagoDataList[i].gift_id))
                maxValue = Convert.ToSingle(chicagoDataList[i].gift_id);
        }

        //Spit out the max value
        return maxValue;
    }


    private float FindMinValuePeriodEnd()
    {

        float minValue = Convert.ToSingle(chicagoDataList[0].gift_id);

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < chicagoDataList.Count; i++)
        {
            if (Convert.ToSingle(chicagoDataList[i].gift_id) < minValue)
                minValue = Convert.ToSingle(chicagoDataList[i].gift_id);
        }

        return minValue;
    }

}
