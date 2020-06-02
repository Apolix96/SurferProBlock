using UnityEngine;
using UnityEngine.UI;

public class Diamonds : MonoBehaviour
{

    public Image Diamond;
    RectTransform m_RectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        //Initiate the x and y positions
    }

    // Update is called once per frame
    void Update()
    {
        if (Diamond.rectTransform.anchoredPosition == m_RectTransform.anchoredPosition)
        {
            Destroy(gameObject,.7f);
        }
    }
}
