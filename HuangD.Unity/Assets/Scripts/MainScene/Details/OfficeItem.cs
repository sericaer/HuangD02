using HuangD.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class OfficeItem : MonoBehaviour
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

    protected virtual void FixedUpdate()
    {
        personItem.gameObject.SetActive(obj.currPerson != null);
        personItem.obj = obj.currPerson;
    }
}