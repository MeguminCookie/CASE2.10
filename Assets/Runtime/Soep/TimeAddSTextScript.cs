using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAddSTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gamemanager;
    private CountdownTimer timer;
    [SerializeField] private GameObject timeTextObject;
    [SerializeField] private TextMeshProUGUI timeText;
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        timer = gamemanager.GetComponent<CountdownTimer>();
        timeText.SetText( "-" +timer.GetTimeDamage() + "s");
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Move()
    {
        timeText.transform.DOMoveY(timeText.transform.position.y + 1, 0.8f);
        timeText.DOFade(1, 0.8f); 
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
