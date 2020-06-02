using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GetDiamonds : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject Diamond;
    public Text scoreText;
    public int score;

    void CreateDiamond()
    {
        var createImage = Instantiate(Diamond) as GameObject;
        createImage.transform.SetParent(canvas.transform, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            CreateDiamond();
            Destroy(other.gameObject);
            score++;
            ChangeTime();
        }
    }
    public void StartScore()
    {
        var s = DOTween.Sequence();
        var count = 10;
        var delay = 1f;
        for (int i = 0; i < count; i++)
        {
            s.InsertCallback(i * delay, ChangeTime);
        }
    }
    void ChangeTime()
    {
        scoreText.text = string.Format("<color=lime>{0}</color>", score);
    } 
}

