using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface ITake
{
    void Enter();

    void UpdateMove(Vector3 target);

    void Exit();
}
