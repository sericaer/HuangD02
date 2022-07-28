using HuangD.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class PartyPanel : MonoBehaviour
{
    public Text partyName;

    public IParty obj;

    void FixedUpdate()
    {
        partyName.text = obj?.name;
    }
}