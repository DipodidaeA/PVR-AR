using UnityEngine;
using UnityEngine.UI;

public class ToggleManage : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;

    private const string Toggle1Key = "Toggle1State";
    private const string Toggle2Key = "Toggle2State";

    public void SaveToggles()
    {
        PlayerPrefs.SetInt(Toggle1Key, toggle1.isOn ? 1 : 0);
        PlayerPrefs.SetInt(Toggle2Key, toggle2.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void RestoreToggles()
    {
        toggle1.isOn = PlayerPrefs.GetInt(Toggle1Key, 0) == 1;
        toggle2.isOn = PlayerPrefs.GetInt(Toggle2Key, 0) == 1;
    }
}
