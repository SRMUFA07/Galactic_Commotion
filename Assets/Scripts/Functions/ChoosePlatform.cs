using UnityEngine;
using UnityEngine.UI;

public class ChoosePlatform : MonoBehaviour
{
    public static bool pcDevise;
    public GameObject _mainCamera;

    public void PcButtonDown() 
    {
        pcDevise = true;
        _mainCamera.layer = 9;
        Time.timeScale = 1;
    }

    public void PhoneButtonDown() 
    {
        pcDevise = false;
        _mainCamera.layer = 1;
        Time.timeScale = 1;
    }
}
