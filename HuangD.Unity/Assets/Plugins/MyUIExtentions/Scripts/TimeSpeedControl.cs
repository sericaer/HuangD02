using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[AddComponentMenu("UI/MyUIExtentions/TimeSpeedControl")]
public class TimeSpeedControl : MonoBehaviour
{
    public static TimeSpeedControl inst;

    public Button speedInc;
    public Button speedDec;
    public Toggle speedPause;
    public TimeIncEvent timeIncEvent;

    public int speed { get; set; }
    public bool isSysPause { get; set; }

    public bool isUserPause => speedPause.isOn;

    public bool isPause => isSysPause || isUserPause;

#if UNITY_EDITOR
    public int MAX_SPEED => 10;
#else
    public int MAX_SPEED => 4;
#endif
    public int MIN_SPEED => 1;


    internal static GameObject CreateGameObject(GameObject parent)
    {
        GameObject instance = (GameObject)Instantiate(Resources.Load("TimeSpeedControl"), parent.transform);
        return instance;
    }

    void Start()
    {
        inst = this;

        isSysPause = false;

#if UNITY_EDITOR
        speed = MAX_SPEED;
#else
        speed = 1;
#endif


        UpdateSpeedControl();

        speedInc.onClick.AddListener(() =>
        {
            speed++;
            UpdateSpeedControl();
        });

        speedDec.onClick.AddListener(() =>
        {
            speed--;
            UpdateSpeedControl();
        });

        speedPause.onValueChanged.AddListener((value) =>
        {
            UpdateSpeedControl();
        });

        StartCoroutine(OnTimer());
    }

    private void UpdateSpeedControl()
    {
        speedInc.interactable = !speedPause.isOn && speed < MAX_SPEED;
        speedDec.interactable = !speedPause.isOn && speed > MIN_SPEED;
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1.0f / speed);
        yield return new WaitUntil(() => !isPause);

        timeIncEvent?.Invoke();

        StartCoroutine(OnTimer());
    }
}

[System.Serializable]
public class TimeIncEvent : UnityEvent
{

}
