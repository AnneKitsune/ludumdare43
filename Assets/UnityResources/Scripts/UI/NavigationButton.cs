using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour
{
    public CanvasGroup toEnable;
    public CanvasGroup toDisable;
    public float fadeSpeed;

    bool triggered;
    // Use this for initialization
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate
            {
                toEnable.gameObject.SetActive(true);

                Invoke("ToDisable", 1f);

                triggered = true;
            });
    }
	
    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            toEnable.alpha += Time.deltaTime * fadeSpeed;
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
        toDisable.gameObject.SetActive(false);
    }
}
