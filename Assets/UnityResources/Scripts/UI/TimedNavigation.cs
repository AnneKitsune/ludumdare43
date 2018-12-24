using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimedNavigation : MonoBehaviour
{
    public CanvasGroup toEnable;
    public CanvasGroup toDisable;
    public float fadeSpeed;
    public float time;

    bool triggered;
    // Use this for initialization

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        triggered = true;
        toEnable.gameObject.SetActive(true);

        Invoke("ToDisable", 1f);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            toEnable.alpha += Time.deltaTime * fadeSpeed;
            if (toDisable)
                toDisable.alpha -= Time.deltaTime * fadeSpeed;

            if (toEnable.alpha >= 1f)
                triggered = false;
        }
    }

    void ToEnable()
    {
        toEnable.gameObject.SetActive(true);
    }

    void ToDisable()
    {
        if (toDisable)
            toDisable.gameObject.SetActive(false);
    }
}
