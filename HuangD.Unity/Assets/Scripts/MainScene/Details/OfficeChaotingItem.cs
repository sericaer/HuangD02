using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class OfficeChaotingItem : MonoBehaviour
{
    public Text label;
    public PersonInOfficeItem personItem;

    public IOffice obj
    {
        get
        {
            return _obj;
        }
        set
        {
            _obj = value;
            label.text = _obj.name;
        }
    }

    private IOffice _obj;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        personItem.gameObject.SetActive(obj.currPerson != null);
        personItem.obj = obj.currPerson;
    }
}