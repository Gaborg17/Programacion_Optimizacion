using System.Collections;
using UnityEngine;
using SimpleJSON;
using static System.Net.WebRequestMethods;
using UnityEngine.Networking;

public class WeatherHandler : MonoBehaviour
{

    [SerializeField] private float lat;
    [SerializeField] private float lon;
    [SerializeField] private WeatherData wData;

    private string apiKey = "ad91d177b783b43d511588f36f6621df";
    private string url;

    private string jsonRAW;

    private void Start()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=minutely,hourly,daily&appid={apiKey}&units=metric";

        StartCoroutine(UpdateWeather());
    }

    IEnumerator UpdateWeather()
    {
        UnityWebRequest request = new UnityWebRequest(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
                    
        }
        else
        {
            jsonRAW = request.downloadHandler.text;
            Debug.Log(jsonRAW);

            ReadJson();
        }



    }
    private void ReadJson()
    {
        var weatherJson = JSON.Parse(jsonRAW);

        wData.timezone = weatherJson["timezone"].Value;
        wData.temp = float.Parse(weatherJson["current"]["temp"].Value);
        wData.weatherDescription = weatherJson["current"]["weather"][0]["description"].Value;
    }
}
