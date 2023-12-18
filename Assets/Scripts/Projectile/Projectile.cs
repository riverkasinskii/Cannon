using System.Collections;
using UnityEngine;

public sealed class Projectile : MonoBehaviour, IExecuteAfterTime
{
    private Rigidbody rb;    

    private void Awake()
    {
        TryGetComponent(out Rigidbody rb);
        this.rb = rb;        
    }        

    public IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
    }
}
