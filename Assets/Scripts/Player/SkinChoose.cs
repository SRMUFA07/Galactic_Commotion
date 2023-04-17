using UnityEngine;

public class SkinChoose : MonoBehaviour
{
    public Sprite[] _skins;

    public GameObject _player;

    private void Update()
    {
        SetSkin();
    }

    private void SetSkin()
    {
        _player.GetComponent<SpriteRenderer>().sprite = _skins[PlayerPrefs.GetInt("skinNumber")];
    }
}
