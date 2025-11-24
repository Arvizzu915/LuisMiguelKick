using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickDetection : MonoBehaviour
{
    public List<IKickable> kickableObjectsBeingDetected = new();

    public List<GameObject> kickables = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IKickable kickableObj))
        {
            kickables.Add(other.gameObject);
            kickableObjectsBeingDetected.Add(kickableObj);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IKickable kickableObj))
        {
            kickables.Remove(other.gameObject);
            StartCoroutine(DetectionCoyoteTime(kickableObj));
        }
    }

    private IEnumerator DetectionCoyoteTime(IKickable kickable)
    {
        yield return new WaitForSeconds(.2f);
        kickableObjectsBeingDetected.Remove(kickable);
    }
}
