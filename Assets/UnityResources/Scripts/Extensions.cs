using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using UnityEngine.Events;

public static class Extensions
{

    public static void LookAt2D(this Transform t, Vector3 target, float angleSubstraction = 0f)
    {
        Vector3 dir = target - t.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - angleSubstraction;
        t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public static void SmoothLookAt2D(this Transform t, Vector3 target, float speed, float angleSubstraction = 0f)
    {
        Vector3 dir = (Vector3)target - t.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - angleSubstraction;
        t.rotation = Quaternion.Lerp(t.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * speed);
    }

    public static void LookAtDir2D(this Transform t, Vector3 dir)
    {
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public static void SmoothLookAtDir2D(this Transform t, Vector3 dir, float speed)
    {
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        t.rotation = Quaternion.Lerp(t.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * speed);
    }


    public static Vector3 Flattened(this Vector3 v3, float zPosition = 0f)
    {
        return new Vector3(v3.x, v3.y, zPosition);
    }

    public static Color Invert(this Color color)
    {
        return new Color(1.0f - color.r, 1.0f - color.g, 1.0f - color.b);
    }

    public static Color SetAlpha(this Color c, float a)
    {
        return new Color(c.r, c.g, c.b, a);
    }

    public static void SetPSEmissionRate(this ParticleSystem ps, float rate)
    {
        var m = ps.emission;
        m.rateOverTimeMultiplier = rate;
    }

    public static void EmitAt(this ParticleSystem ps, int count, Vector3 pos)
    {
        ps.transform.position = pos;
        ps.Emit(count);
    }

    public static IEnumerator SetActiveDelayedEnumerator(this MonoBehaviour m, float delay, bool active, bool self = false)
    {
        yield return new WaitForSeconds(delay);
        if (!self)
            m.gameObject.SetActive(active);
        else
            m.enabled = false;
    }

    public static void SetActiveDelayed(this MonoBehaviour m, float delay, bool active, bool self = false)
    {
        m.StartCoroutine(m.SetActiveDelayedEnumerator(delay, active, self));
    }

    public static bool Draw(float chance)
    {
        if (chance <= 0f)
            return false;
        return chance >= UnityEngine.Random.value;
    }

    public static bool Draw(float chance, out float chanceFactor)
    {
        if (chance <= 0f)
        {
            chanceFactor = 0f;
            return false;
        }

        float r = UnityEngine.Random.value;

        chanceFactor = ((chance - r) / chance) + 1f;
        return chance >= UnityEngine.Random.value;
    }

    public static bool FastApproximately(float v1, float v2, float threshold)
    {
        return (v1 > v2 ? (v1 - v2) : (v2 - v1)) <= threshold;
    }

    public static void ChangeColor(this ParticleSystem ps, Color c)
    {
        var v = ps.main;
        v.startColor = c;
    }

    public static bool IsInRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }

    public static bool IsAngleInRange(float angle, float minAngle, float maxAngle)
    {
        //We suppose max angle [0, 360] and min angle [-360, 360]
        if (minAngle >= 0)
        {
            return IsInRange(angle, minAngle, maxAngle);
        }

        return IsInRange(angle, minAngle + 360f, 360f) || IsInRange(angle, 0f, maxAngle);
    }

    public static float Normalize(float value)
    {
        return value / Mathf.Abs(value);
    }

    public static Vector3 GetMouseWorldPos()
    {
        Vector3 vec = Input.mousePosition;
        //CANVAS PLANE DISTANCE
        vec.z = 100f;           
        return Camera.main.ScreenToWorldPoint(vec);
    }

    public static Vector2 GetRandomPosOffScreen()
    {
        return UnityEngine.Random.insideUnitCircle.normalized * 12f;
    }


    public static bool HasInternet()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                using (var stream = client.OpenRead("http://google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public static void PlayOneShot(this AudioSource a, AudioClip clip, float volumeScale = 1f, float pitch = 1f)
    {
        a.pitch = pitch;
        a.PlayOneShot(clip, volumeScale);
    }

    //
    public static void PlayOneShotDelayed(this MonoBehaviour b, AudioSource audioSource, float delay)
    {
        b.StartParamsCoroutine(audioSource.PlayOneShot, audioSource.clip, delay);
    }

    public static IEnumerator InvokeParams<T>(Action<T> a, T arg1, float delay)
    {
        yield return new WaitForSeconds(delay);
        a.Invoke(arg1);
    }

    public static IEnumerator InvokeParams<T, U>(Action<T, U> a, T arg1, U arg2, float delay)
    {
        yield return new WaitForSeconds(delay);
        a.Invoke(arg1, arg2);
    }

    public static IEnumerator InvokeParams<T, U, V>(Action<T, U, V> a, T arg1, U arg2, V arg3, float delay)
    {
        yield return new WaitForSeconds(delay);
        a.Invoke(arg1, arg2, arg3);
    }

    public static void StartParamsCoroutine<T>(this MonoBehaviour o, Action<T> a, T arg1, float delay)
    {
        o.StartCoroutine(InvokeParams(a, arg1, delay));
    }

    public static void StartParamsCoroutine<T, U>(this MonoBehaviour o, Action<T, U> a, T arg1, U arg2, float delay)
    {
        o.StartCoroutine(InvokeParams(a, arg1, arg2, delay));
    }

    public static void StartParamsCoroutine<T, U, V>(this MonoBehaviour o, Action<T, U, V> a, T arg1, U arg2, V arg3, float delay)
    {
        o.StartCoroutine(InvokeParams(a, arg1, arg2, arg3, delay));
    }
        
}

public class Tuple<T1, T2>
{
    public T1 value1{ get; set; }

    public T2 value2{ get; set; }

    public Tuple(T1 value1, T2 value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }
}

[System.Serializable]
public class BoolUEvent : UnityEvent<bool>
{
}

[System.Serializable]
public class Range
{
    public float min;
    public float max;

    public float Length{ get { return max - min; } }

    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float Lerp(float t)
    {
        return Mathf.Lerp(min, max, t);
    }

    public float RandomNumberInRange()
    {
        return UnityEngine.Random.Range(min, max);
    }
}
