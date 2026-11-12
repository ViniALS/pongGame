using UnityEngine;
using TMPro;
using UnityEngine.UIElements.Experimental;
public class ScoreText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI text;

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }
}
