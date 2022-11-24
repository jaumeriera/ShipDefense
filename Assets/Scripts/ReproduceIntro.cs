using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReproduceIntro : MonoBehaviour
{
    [SerializeField] GameObject GUI;
    [SerializeField] TextMeshProUGUI intro;

    [SerializeField] float FadeInTime;
    [SerializeField] float FadeInStayTime;
    [SerializeField] float FadeOutTime;
    [SerializeField] float FadeOutStayTime;

    float timeChecker;
    Color TextColor;

    private void Start() {
        GUI.SetActive(false);
        TextColor = intro.color;
        timeChecker = 0;
        StartCoroutine(DoBlink());
    }

    private IEnumerator DoBlink() {
        bool mustBlink = true;
        while (mustBlink) {
            timeChecker += Time.deltaTime;
            if (timeChecker < FadeInTime) {
                intro.color = new Color(TextColor.r, TextColor.g, TextColor.b, timeChecker / FadeInTime);
                yield return null;
            }
            else if (timeChecker < FadeInTime + FadeInStayTime) {
                intro.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1);
                yield return null;
            }
            else if (timeChecker < FadeInTime + FadeInStayTime + FadeOutTime) {
                intro.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1 - (timeChecker - (FadeInTime + FadeInStayTime)) / FadeOutTime);
                yield return null;
            }
            else if (timeChecker < FadeInTime + FadeInStayTime + FadeOutTime + FadeOutStayTime) {
                yield return null;
            }
            else {
                mustBlink = false;
                timeChecker = 0;
            }
        }
        GUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
