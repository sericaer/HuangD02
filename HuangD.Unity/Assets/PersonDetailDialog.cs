using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonDetailDialog : MonoBehaviour
{
    public Text Name;
    public Text Score;

    public IPerson obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Name.text = obj?.fullName;
        Score.text = obj?.score?.ToString();
    }
}
