using System.Collections.Generic;
using UnityEngine;

public sealed class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private List<Target> poolTargets;

    [SerializeField] private float timeToRespawn = 3f;

    private void Awake()
    {
        foreach (var target in poolTargets)
        {
            target.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (var target in poolTargets)
        {
            if (!target.gameObject.activeSelf)
            {
                ActiveSelfObject(target);
            }
        }
    }

    private void ActiveSelfObject(Target target)
    {
        StartCoroutine(target.ExecuteAfterTime(timeToRespawn));
    }
}
