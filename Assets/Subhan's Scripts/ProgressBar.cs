using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] TMP_Text textLevel;
    [SerializeField] private Image fillBg;
    [SerializeField] private Color color;
    private int level = 0;
    private float currentAmount = 0;
    public float target;


    private Coroutine routine;


    private void OnEnable()
    {
        fillBg.color = color;
        level = 0;
        currentAmount = 0;
        fillBg.fillAmount = currentAmount;
    }

    public void UpdateProgress(float amount, float duration = .1f)
    {
        if (routine != null)
            StopCoroutine(routine);

        target = currentAmount + amount;
        routine = StartCoroutine(FillRoutine(target, duration));

        Debug.Log("In progress!");
    }

    private IEnumerator FillRoutine(float target, float duration)
    {
        float time = 0;
        float tempAmount = currentAmount;
        float diff = target - tempAmount;
        currentAmount = target;

        while (time < duration)
        {
            time += Time.deltaTime;
            float percent = time / duration;
            fillBg.fillAmount = tempAmount + diff * percent;
            yield return null;
        }

        if (currentAmount >= .5f)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        UpdateLevel(level + 1);
        
    }

    public void UpdateLevel(int level)
    {
        this.level = level;
        textLevel.text = "Lv" + this.level.ToString();
    }
}
