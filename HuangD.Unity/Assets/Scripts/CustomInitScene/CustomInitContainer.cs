using System;
using System.Linq;
using UnityEngine;

public class CustomInitContainer : MonoBehaviour
{
    public bool isShowFinishPanel => GetComponentsInChildren<CustomInitPanel>().Length == 0;

    internal void OnNext()
    {
        var panel = GetComponentsInChildren<CustomInitPanel>().Last();
        panel.gameObject.SetActive(false);
    }
}
