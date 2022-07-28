using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyItem : MonoBehaviour
{
    public Text label;
    public IParty obj;

    // Start is called before the first frame update
    void Start()
    {
        FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        label.text = obj?.name;
    }
}
