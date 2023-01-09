using UnityEngine;
using UnityEngine.UI;

public class SkinsControl : MonoBehaviour
{
    public Image padlock;
    public Sprite closeLock;
    public Sprite openLock;

    public int price;
    public CoinSelect _balance;
    public Sprite buySkin;
    
    public Button buyButton;
    public Sprite equipped;
    public Sprite equip;

    public int skinNumber;
    public Image[] skins;

    private void Start() 
    {
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("skin1" == img.name)
                {
                    PlayerPrefs.SetInt("skin1" + "buy", 1);
                    PlayerPrefs.SetInt("skin1" + "equip", 1);
                }
                else
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
            }
        }
    }

    private void Update() 
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            padlock.GetComponent<Image>().sprite = closeLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }

        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            padlock.GetComponent<Image>().sprite = openLock;

            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
                buyButton.GetComponent<Image>().sprite = equipped;
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
                buyButton.GetComponent<Image>().sprite = equip;
        }
    }

    public void Buy() 
    {
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0) 
        {
            if (_balance.coinQuality >= price)
            {
                padlock.GetComponent<Image>().sprite = openLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                _balance.coinQuality = _balance.coinQuality - price;
                
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNumber", skinNumber);
                PlayerPrefs.SetInt("Coins", _balance.coinQuality);

                foreach(Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    else
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                } 
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            padlock.GetComponent<Image>().sprite = openLock;
            buyButton.GetComponent<Image>().sprite = equipped;
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNumber", skinNumber);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                else
                    PlayerPrefs.SetInt(img.name + "equip", 0);
            }
        }
    }
}
