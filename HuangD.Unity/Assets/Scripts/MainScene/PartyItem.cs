using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PartyItem : MonoBehaviour
{
    public Text label;
    public Slider slider;

    public IParty obj;

    // Start is called before the first frame update
    void Start()
    {
        FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(obj != null)
        {
            label.text = obj.name;
            slider.value = obj.power;


            slider.maxValue = Global.session.chaoting.all.Sum(x => ((IChaotingOfficeDef)x.def).power);
        }
    }
}
