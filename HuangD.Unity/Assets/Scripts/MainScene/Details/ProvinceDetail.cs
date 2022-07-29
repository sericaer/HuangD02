using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceDetail : MonoBehaviour
{
    public Text Label;
    public Text masterOffice;
    public Text masterName;
    public Text popCount;

    public IProvince obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Label.text = obj?.name;
        masterOffice.text = obj?.masterOffice.name;
        masterName.text = obj?.masterOffice?.currPerson?.fullName;
        popCount.text = obj?.popCount.ToString();
    }
}
