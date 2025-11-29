using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IDraggable
{
    void OnGrab();

    void UpdateMove(Vector3 target);

    void OnRealese();
}
