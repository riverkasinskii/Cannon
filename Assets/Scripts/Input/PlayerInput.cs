using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private RotateBase rotatebase;

    [SerializeField] private float powerShot;
    [SerializeField] private ProjectileBehaviour projectileSpawner;

    public void Update()
    {
        RotateCannon();
        ShootProjectile();
    }

    private void RotateCannon()
    {
        Vector2 axis = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rotatebase.Rotate(rotationSpeed * Time.deltaTime * axis);
    }

    private void ShootProjectile()
    {
        projectileSpawner.Shot(Input.GetKeyDown(KeyCode.Space));
    }
}
   
