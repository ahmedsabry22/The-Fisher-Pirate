using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Slider oxygenSlider;
    public Text oxygenPercentText;

    private const int initialPercent = 100;
    private int currentPercent = initialPercent;

    private void Start()
    {
        StartCoroutine(OxygenPercentage());
    }

    private IEnumerator OxygenPercentage()
    {
        while (currentPercent > 0)
        {
            currentPercent -= 1;
            oxygenSlider.value = currentPercent;
            oxygenPercentText.text = oxygenSlider.value + "%";
            yield return (new WaitForSeconds(0.5f));
        }

        if (!Mission.Instance.Won)
            Mission.Instance.OnMissionLose();
    }
}