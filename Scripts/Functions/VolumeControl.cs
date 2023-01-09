using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Sprite _soundOn;
    public Sprite _soundOff;
    public GameObject _soundOnOffButton;

    public void VolumeOffOn()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _soundOnOffButton.GetComponent<Image>().sprite = _soundOff;
        }
        else
        {
            AudioListener.volume = 1;
            _soundOnOffButton.GetComponent<Image>().sprite = _soundOn;
        }
    }
}
