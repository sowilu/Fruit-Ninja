using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TextMeshProUGUI scoreText;

    public UnityEvent<int> OnCombo;
    public float comboTimer = 1f;


    private int combo = 1;
    private float lastHit = 0;
    private int score = 0;

    public int Points{
        get => score;
        set
        {
            score = value;

            if(lastHit + comboTimer > Time.time)
            {
                combo++;
                value += combo;

                OnCombo.Invoke(combo);
            }
            else if(combo > 1)
            {
                print("Added combo: " + combo);
                score += combo;
                combo = 1;
                OnCombo.Invoke(0);
            }
            lastHit = Time.time;

            scoreText.text = score.ToString();

            scoreText.transform.DOScale(Vector3.one, 0.3f)
            .From(Vector3.zero)
            .SetEase(Ease.OutElastic);
        }
    }

    void Awake()
    {
        //initialise singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
