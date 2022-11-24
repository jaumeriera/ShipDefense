using Feto;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShipLife : Singleton<ShipLife>
{
    [SerializeField] int maxHits;
    [SerializeField] Image shield;

    int currentHits;

    private void Start() {
        shield.fillAmount = 1;
        currentHits = 0;
    }

    public void ApplyDamage() {
        currentHits += 1;
        UpdateShieldStatus();
        if(currentHits > maxHits) {  // Game Over
            PlayerPrefs.SetInt("Score", ScoreManager.Instance.score);
            SceneManager.LoadScene(1);
        }
    }

    private void UpdateShieldStatus() {
        shield.fillAmount = (maxHits - currentHits) / (float)maxHits;
    }

}
