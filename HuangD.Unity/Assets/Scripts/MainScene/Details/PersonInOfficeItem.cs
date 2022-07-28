
using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PersonInOfficeItem : MonoBehaviour
{
    public Text personName;
    public PartyPanel partyPanel;

    public IPerson obj;
    
    void FixedUpdate()
    {
        personName.text = obj?.fullName;

        if(partyPanel != null)
        {
            partyPanel.obj = obj?.party;
        }
    }
}
