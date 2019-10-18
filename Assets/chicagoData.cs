using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Grab an API dataset from https://data.cityofchicago.org/
/// Use http://json2csharp.com/ to generate a c# class from the JSON
/// Copy and paste the class variables in the class below
/// </summary>


[System.Serializable]
public class chicagoData
{

    // this data is for lobbyists, their expenditures, and their clients

    public string gift_id;
    public System.DateTime period_start;
    public System.DateTime period_end;
    public string gift;
    public string recipient_first_name;
    public string recipient_last_name;
    public string recipient_title;
    public string value;
    public string department;
    public string lobbyist_id;
    public string lobbyist_firstname;
    public string lobbyist_lastname;
    public System.DateTime created_date;


}

