using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartCountdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int secondsToRestart;
    [SerializeField] TextMeshProUGUI info;

    string fixedInfo = "Game restarting in: ";
    int remainingSeconds;
    void Start()
    {
        remainingSeconds = secondsToRestart;
        scoreText.SetText(PlayerPrefs.GetInt("Score").ToString());
        StartCoroutine(Countdown());


    }

    IEnumerator Countdown() {
        while (remainingSeconds > -1) {
            UpdateText();
            yield return new WaitForSeconds(1f);
            remainingSeconds -= 1;
        }
        SceneManager.LoadScene(0);  //Return to main scene  
    }

    private void UpdateText() {
        info.SetText(fixedInfo + remainingSeconds.ToString() + "s");
    }    
}
