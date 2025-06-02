using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all bullets.
/// </summary>
public interface IBullet
{
    void SetTower(Tower t);
    void SetMedicine(Medicine med);
	Medicine GetMedicine();
    void Fire(Transform target);
}
