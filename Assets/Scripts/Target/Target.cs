using System.Collections;
using UnityEngine;

public sealed class Target : MonoBehaviour, IExecuteAfterTime
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);        
    }

    public IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        gameObject.SetActive(true);        
    }
}
