using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightTextAndFillImage2 : MonoBehaviour
{
    public TextMeshProUGUI printText;
    public TextMeshProUGUI levelText;
    public Image levelImage;

    private void Start()
    {
        StartCoroutine(HighlightTextAndFillImage2Coroutine());
    }

    private IEnumerator HighlightTextAndFillImage2Coroutine()
    {
        while (true)
        {
            levelText.color = Color.yellow;
            printText.color = Color.black;
            float startFillAmount = 0.50f;
            float endFillAmount = 0.95f;
            float fillAmount = startFillAmount;

            while (fillAmount <= endFillAmount)
            {
                levelImage.fillAmount = fillAmount;
                fillAmount += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1);
            printText.color = Color.white;
            levelText.color = Color.white;

            fillAmount = endFillAmount;

            while (fillAmount >= startFillAmount)
            {
                levelImage.fillAmount = fillAmount;
                fillAmount -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1);
        }
    }
}
