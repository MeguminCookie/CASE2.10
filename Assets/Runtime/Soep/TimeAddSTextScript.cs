using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAddSTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gamemanager;
    private CountdownTimer timer;
    [SerializeField] private TextMeshProUGUI timeText;
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        timer = gamemanager.GetComponent<CountdownTimer>();
        timeText.SetText(timer.GetTimeDamage() + "s");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Move()
    {
        
        yield return new WaitForSeconds(0.8f);
    }
}
