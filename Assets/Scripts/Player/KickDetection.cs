using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickDetection : MonoBehaviour
{
    [SerializeField] private float detectionCoyoteTime = 0.2f;

    public readonly List<IKickable> kickablesDetected = new();

    private readonly Dictionary<IKickable, Coroutine> activeCoyoteTimers = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IKickable kickable))
        {
            // Cancel coyote timer if active
            if (activeCoyoteTimers.ContainsKey(kickable))
            {
                StopCoroutine(activeCoyoteTimers[kickable]);
                activeCoyoteTimers.Remove(kickable);
            }

            if (!kickablesDetected.Contains(kickable))
                kickablesDetected.Add(kickable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IKickable kickable))
        {
            if (activeCoyoteTimers.ContainsKey(kickable))
                StopCoroutine(activeCoyoteTimers[kickable]);

            Coroutine timer = StartCoroutine(CoyoteRemoval(kickable));
            activeCoyoteTimers[kickable] = timer;
        }
    }

    private IEnumerator CoyoteRemoval(IKickable kickable)
    {
        yield return new WaitForSeconds(detectionCoyoteTime);

        kickablesDetected.Remove(kickable);
        activeCoyoteTimers.Remove(kickable);
    }
}
