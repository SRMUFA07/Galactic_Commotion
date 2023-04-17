using Assets.Yandex;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance;

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [DllImport("__Internal")]
    private static extern void GetTypePlatformDevice();

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GetTypePlatformDevice();
    }

    public void ShowAdvOnClick() => 
        ShowAdv();

    public void GetPlatformDevice() => 
        GetTypePlatformDevice();

    public DeviceTypeEnum CurrentDeviceType { get; private set; }

    public void SetTargetDevice(string deviceType)
    {
        switch (deviceType)
        {
            case "desktop":
                CurrentDeviceType = DeviceTypeEnum.Desktop;
                break;
            case "tablet":
                CurrentDeviceType = DeviceTypeEnum.Mobile;
                break;
            default:
                CurrentDeviceType = DeviceTypeEnum.Mobile;
                break;
        }
    }
}
