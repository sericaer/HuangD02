using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceDetail : MonoBehaviour
{
    public Text Label;

    public IProvince obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Label.text = obj?.name;
    }
}
