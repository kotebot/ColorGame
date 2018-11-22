using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text score;
    public Text maxScore;

    public void Awake()
    {
        ShermanLibr.ScoreSystem.Inicial();
    }

    public void Update()
    {
        score.text = ShermanLibr.ScoreSystem.Score.ToString();
        maxScore.text = ShermanLibr.ScoreSystem.MaxScore.ToString();
    }

}
