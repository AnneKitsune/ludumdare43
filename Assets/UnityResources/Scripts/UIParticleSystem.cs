using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParticleSystem : MonoBehaviour
{
    [Tooltip("The orginal Gameobject containing the Image to be duplicated")]
    public GameObject particle;

    public Transform holder;

    [HideInInspector]
    List<GameObject> particlePool = new List<GameObject>();

    public bool isPlaying;

    public Gradient randomColor;
    public bool isRandomColor;

    public bool isOutlined;
    public Gradient outlineRandomColor;
    public bool isOutlineRandomColor;

    public bool fadeIn;
    public bool fadeOut;

    public float rate;
    public float lifeTime;

    public Vector2 speed;
    public bool isRandomSpeedDirection;

    public Vector2 maxPositionOffset;

    public float maxSizeScale;

    public bool setDynamicText;

    private int startPoolCount;

    private Color currentNonRandomColor;
    private Color currentNonRandomOutlineColor;
    private Vector3 initialScale;
    private Text originText;

    // Use this for initialization
    void Start()
    {
        startPoolCount = (int)(rate * rate * lifeTime);
        for (int i = 0; i < startPoolCount; i++)
        {
            GameObject p = (GameObject)Instantiate(particle, Vector3.zero, Quaternion.identity, holder);
            p.SetActive(false);
            particlePool.Add(p);
        }
        initialScale = particle.transform.localScale;
        originText = particle.GetComponent<Text>();
        StartCoroutine(Emission());
    }

    IEnumerator Emission()
    {
        while (true)
        {
            Emit(1);
            yield return new WaitForSecondsRealtime(1f / rate);
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        currentNonRandomColor = randomColor.Evaluate(Mathf.PingPong(Time.time, 1f));
        currentNonRandomOutlineColor = outlineRandomColor.Evaluate(Mathf.PingPong(Time.time, 1f));
    }

    public void Emit(int number = 1)
    {
        if (isPlaying)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject p = GetFreeParticle();
                Graphic g = p.GetComponent<Graphic>();
                Outline ot = null;
                if (isOutlined)
                    ot = p.GetComponent<Outline>();
                if (setDynamicText)
                    p.GetComponent<Text>().text = originText.text;
                TimedDisable td = p.GetComponent<TimedDisable>();

                //Color apply
                if (isRandomColor)
                    g.color = randomColor.Evaluate(Random.value);
                else
                    g.color = currentNonRandomColor;

                if (ot != null)
                {
                    if (isOutlineRandomColor)
                        ot.effectColor = outlineRandomColor.Evaluate(Random.value);
                    else
                        ot.effectColor = currentNonRandomOutlineColor;
                }

                if (fadeIn && !fadeOut)
                {
                    g.canvasRenderer.SetAlpha(0f);
                    g.CrossFadeAlpha(1f, lifeTime, true);
                }
                
                if (fadeOut && !fadeIn)
                {
                    g.canvasRenderer.SetAlpha(1f);
                    g.CrossFadeAlpha(0f, lifeTime, true);
                }

                if (fadeIn && fadeOut)
                {
                    g.canvasRenderer.SetAlpha(0f);
                    g.CrossFadeAlpha(1f, lifeTime / 2f, true);
                    g.StartParamsCoroutine(g.CrossFadeAlpha, 0f, lifeTime / 2f, true, lifeTime / 2f);
                }

                //Position
                p.transform.position = (Vector2)transform.position + new Vector2(Random.Range(-maxPositionOffset.x, maxPositionOffset.x), Random.Range(-maxPositionOffset.y, maxPositionOffset.y));
                p.transform.rotation = particle.transform.rotation;
                if (maxSizeScale > 0f)
                {
                    p.transform.localScale = initialScale;
                    p.transform.localScale = Vector2.Lerp(p.transform.localScale, p.transform.localScale * maxSizeScale, Random.value);
                }

                //Speed
                if (speed.magnitude != 0f)
                {
                    Move m = p.GetComponent<Move>();
                    if (isRandomSpeedDirection)
                        m.velocity = Random.insideUnitCircle * speed.magnitude;
                    else
                        m.velocity = speed;
                }

                //Duration
                td.delay = lifeTime;
                td.StopAllCoroutines();
                td.StartCoroutine(td.Start());

                p.SetActive(true);
            }
        }
    }

    public GameObject GetFreeParticle()
    {
        foreach (GameObject p in particlePool)
        {
            if (!p.activeInHierarchy)
            {
                p.SetActive(true);
                return p;
            }
        }

        //We add a new Particle
        GameObject newp = (GameObject)Instantiate(particle, Vector3.zero, Quaternion.identity, holder);
        newp.SetActive(true);
        particlePool.Add(newp);
        return newp;
    }
        
}
