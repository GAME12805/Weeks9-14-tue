using System.Collections;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public Transform structure;
    public AnimationCurve rotationCuver;
    public Transform canopyTransform;
    public AnimationCurve canopy;
    public float fallSpeed = 2;

    void Start()
    {
        
    }


    public void Collapse()
    {
        StartCoroutine(DoCollapse());
    }

    IEnumerator DoCollapse()
    {
        yield return StartCoroutine(LampFall());
        yield return StartCoroutine(CanopyFall());
    }

    IEnumerator LampFall()
    {
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime;
            Vector3 rot = structure.eulerAngles;
            rot.z = rotationCuver.Evaluate(t);
            structure.eulerAngles = rot;
            yield return null;
        }
    }

    IEnumerator CanopyFall()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            Vector3 rot = canopyTransform.eulerAngles;
            rot.z = rotationCuver.Evaluate(t);
            canopyTransform.eulerAngles = rot;

            Vector2 pos = canopyTransform.position;
            pos.y -= fallSpeed * Time.deltaTime;
            canopyTransform.position = pos;
            yield return null;
        }

    }
}
