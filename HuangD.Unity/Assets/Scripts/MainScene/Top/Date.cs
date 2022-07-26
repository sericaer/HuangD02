using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    public Text yearName;
    public Text year;
    public Text month;
    public Text day;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yearName.text = Global.session.yearName;
        year.text = Global.session.date.year.ToString();
        month.text = Global.session.date.month.ToString();
        day.text = Global.session.date.day.ToString();
    }
}
