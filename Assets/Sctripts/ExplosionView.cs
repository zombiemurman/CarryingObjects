using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionView
{
    private ParticleSystem _ExplosionEffectPrefab;

    public ExplosionView(ParticleSystem explosionEffectPrefab)
    {
        _ExplosionEffectPrefab = explosionEffectPrefab;
    }

    public void ExplosionEffect(Vector3 position)
    {
        Vector3 positionExplosion = new Vector3(position.x, position.y + 1, position.z);
        Object.Instantiate(_ExplosionEffectPrefab, positionExplosion, Quaternion.identity);
    }
}
