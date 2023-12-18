using System.Collections.Generic;
using UnityEngine;

public sealed class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private List<Projectile> poolProjectiles;

    [SerializeField] private Transform placeForSpawn;
        
    [SerializeField] private float powerShoot = 10f;

    [SerializeField] private float lifeTimeProjectiles = 3f;
                
    private void Awake()
    {        
        foreach (var projectile in poolProjectiles)
        {
            projectile.gameObject.SetActive(false);
        }
    }
        
    public void Shot(bool input)
    {
        if (!input) { return; }

        foreach (var projectile in poolProjectiles)
        {
            if (!projectile.gameObject.activeSelf)
            {
                projectile.gameObject.SetActive(true);
                projectile.transform.position = placeForSpawn.transform.position;
                projectile.GetComponent<Rigidbody>().AddForce(
                    placeForSpawn.transform.position * powerShoot,
                    ForceMode.Impulse);
                ActiveSelfObject(projectile);
                break;
            }
        }
    }

    private void ActiveSelfObject(Projectile projectile)
    {
        StartCoroutine(projectile.ExecuteAfterTime(lifeTimeProjectiles));
    }
}
