using UnityEngine;

public class GamePause : MonoBehaviour
{
    public void PauseButtonDown() =>
        Time.timeScale = 0;

    public void ContinueButtonDown() =>
        Time.timeScale = 1;
}
