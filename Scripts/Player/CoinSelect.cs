using UnityEngine;
using UnityEngine.UI;

public class CoinSelect : MonoBehaviour
{
	public AudioSource _pickUpCoin;
    public Text _coinQualityCanvas;
	public int coinQuality;

	public Text _balanceQualityCanvas;

    private void Start()
    {
		UploadSave();
    }

    private void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "SilverCoin")
		{
			Destroy(other.gameObject);
			coinQuality = coinQuality + 5;
			_pickUpCoin.Play();
			PlayerPrefs.SetInt("Coins", coinQuality);
			_coinQualityCanvas.text = ": " + coinQuality.ToString();

			_balanceQualityCanvas.text = ": " + coinQuality.ToString() + "$";
		}

        if (other.tag == "BronzeCoin")
        {
            Destroy(other.gameObject);
            coinQuality = coinQuality + 150;
            _pickUpCoin.Play();
            _coinQualityCanvas.text = ": " + coinQuality.ToString();

            _balanceQualityCanvas.text = ": " + coinQuality.ToString() + "$";
        }

        if (other.tag == "GoldCoin") 
		{
			Destroy(other.gameObject);
			coinQuality = coinQuality + 350;
			_pickUpCoin.Play();
			_coinQualityCanvas.text = ": " + coinQuality.ToString();

			_balanceQualityCanvas.text = ": " + coinQuality.ToString() + "$";
		}
	}
	private void UploadSave()
	{
		if (PlayerPrefs.HasKey("Coins"))
		{
			coinQuality = PlayerPrefs.GetInt("Coins");
			
			_coinQualityCanvas.text = ": " + coinQuality.ToString();
			_balanceQualityCanvas.text = ": " + coinQuality.ToString() + "$";
		}
	}
}
