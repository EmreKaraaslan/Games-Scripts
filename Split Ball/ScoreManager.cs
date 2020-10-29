using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CountText;

    private int count;

    public void Start()
    {
        count = 0;
        CountText.text = "Score: " + count;
    }

    public void AddPoints(int amount)
    {
        count = count + amount;
        CountText.text = "Score: " + count;
    }

}