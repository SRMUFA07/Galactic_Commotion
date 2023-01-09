using UnityEngine;

public class LinksURL : MonoBehaviour
{
    public void OpenLink(string URL)
    {
        Application.OpenURL(URL);
    }
}
