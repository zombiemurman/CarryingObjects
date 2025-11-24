using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosionMouse : MonoBehaviour
{
    [SerializeField] private float _radius = 3;

    [SerializeField] private float _powerExplosion = 5;

    [SerializeField] private ParticleSystem _ExplosionEffectPrefab;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                ExplosionEffect(hit.point);

                Collider[] targets = Physics.OverlapSphere(hit.point, _radius);
                foreach (Collider target in targets)
                {
                    Vector3 direction = target.gameObject.transform.position - hit.point;

                    IExplosion explosion = target.GetComponent<IExplosion>();

                    if (explosion != null)
                    {
                        explosion.Initiate(direction.normalized * _powerExplosion);
                    }

                }
            }
        }
    }

    private void ExplosionEffect(Vector3 position)
    {
        Vector3 positionExplosion = new Vector3(position.x, position.y + 1, position.z);
        Instantiate(_ExplosionEffectPrefab, positionExplosion, Quaternion.identity);
    }
}
