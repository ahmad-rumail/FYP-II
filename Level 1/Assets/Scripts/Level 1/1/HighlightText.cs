using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighlightTextAndFillImage : MonoBehaviour
{
    public TextMeshProUGUI printText;
    public TextMeshProUGUI levelText;
    public Image levelImage;

    private void Start()
    {
        StartCoroutine(HighlightTextAndFillImageCoroutine());
    }

    private IEnumerator HighlightTextAndFillImageCoroutine()
    {
        while (true)
        {
            levelText.color = Color.yellow;
            printText.color = Color.black;
            float fillAmount = 0.99f;
            while (fillAmount >= 0)
            {
                levelImage.fillAmount = fillAmount;
                fillAmount -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1);
            printText.color = Color.white;
            levelText.color = Color.white;
            fillAmount = 0;
            while (fillAmount <= 0.99f)
            {
                levelImage.fillAmount = fillAmount;
                fillAmount += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1);

            if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                break;
            }
        }
    }
}