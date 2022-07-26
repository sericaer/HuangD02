using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomEmperor : MonoBehaviour
{
    public InputField familyName;
    public InputField givenName;

    private void Start()
    {
        OnRandomFamily();
        OnRandomGiven();
    }

    public void OnRandomFamily()
    {
        string[] familyNames = Global.modder.familyNames;

        familyName.text = familyNames.ElementAt(Random.Range(0, familyNames.Length));
    }

    public void OnRandomGiven()
    {
        string[] givenNames = Global.modder.givenNames;

        givenName.text = givenNames.ElementAt(Random.Range(0, givenNames.Length));
    }
}