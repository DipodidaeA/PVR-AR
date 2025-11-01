using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ShowWeather : MonoBehaviour
{
    [SerializeField] private TMP_Text infoText;
    [System.Serializable] public class WeatherData { public int temp; }

    // Запуск запиту (наприклад, з кнопки)
    public void GetWeather()
    {
        StartCoroutine(GetWeatherCoroutine());
    }

    private IEnumerator GetWeatherCoroutine()
    {
        string url = "http://localhost:3000/weather";

        using (UnityWebRequest req = UnityWebRequest.Get(url))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                var data = JsonUtility.FromJson<WeatherData>(req.downloadHandler.text);
                if (infoText != null)
                {
                    infoText.text = $"Температура: {data.temp}°C";
                }
            }
            else
            {
                if (infoText != null)
                    infoText.text = "Помилка: " + req.error;
            }
        }
    }
}
