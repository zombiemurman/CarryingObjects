using UnityEngine;

public class ExplosionHandler
{
    private float _radius;
    private float _powerExplosion;

    public ExplosionHandler(float radius, float powerExplosion)
    {
        _radius = radius;
        _powerExplosion = powerExplosion;
    }

    public Vector3 ExplosionPoint { get; private set; }

    public void ProcessExplosion(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ExplosionPoint = hit.point;

            Collider[] targets = Physics.OverlapSphere(ExplosionPoint, _radius);
            foreach (Collider target in targets)
            {
                Vector3 direction = target.gameObject.transform.position - ExplosionPoint;

                IExplodable explosion = target.GetComponent<IExplodable>();

                if (explosion != null)
                {
                    explosion.Explode(direction.normalized * _powerExplosion);
                }
            }
        }
    }
}
