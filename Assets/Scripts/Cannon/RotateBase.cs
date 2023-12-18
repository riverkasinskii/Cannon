using UnityEngine;

public class RotateBase : RotateAxis
{
    [SerializeField] private Transform axis;

    private Vector2 current;

    private void Awake()
    {
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        axis.rotation = Quaternion.Euler(current.y, current.x, 0);
    }

    public override void Rotate(Vector2 vector)
    {
        current.x = Mathf.Clamp(current.x + vector.x, -90, 90);
        current.y = Mathf.Clamp(current.y - vector.y, -30, 0);
        ApplyRotation();
    }

    public Vector2 GetCurrentRotation() => current;
}