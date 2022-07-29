using HuangD.CustomInits;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomCountry : CustomInitPanel
{
    public InputField countryName;
    public InputField yearName;

    private void Start()
    {
        OnRandomCountry();
        OnRandomYearName();
    }

    public void OnRandomCountry()
    {
        string[] countryNames = Global.modder.defs.countryDef.countryNames;

        countryName.text = countryNames.ElementAt(Random.Range(0, countryNames.Length));
    }

    public void OnRandomYearName()
    {
        string[] yearNames = Global.modder.defs.countryDef.yearNames;

        yearName.text = yearNames.ElementAt(Random.Range(0, yearNames.Length));
    }

    public override void GetInitData(ref CustomInit customInit)
    {
        customInit.country = new CountryInit()
        {
            countryName = countryName.text,
            yearName = yearName.text
        };
    }
}