using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance {get; private set;}
    public GameObject projectilePrefab;  // Prefab for the pooled projectiles
    public int poolSize = 10;


    private List<GameObject> projectilePool; 

    void Awake()
    {
        Instance = this;
        InitializeProjectilePool();
    }

    void InitializeProjectilePool()
    {
        projectilePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject proj = Instantiate(projectilePrefab);
            proj.SetActive(false);  // Start with all objects deactivated
            projectilePool.Add(proj);
            proj.transform.SetParent(transform);
        }
    }
    public GameObject GetProjectile()
    {
        // Find an inactive object in the pool
        foreach (GameObject proj in projectilePool)
        {
            if (!proj.activeInHierarchy)
            {
                proj.SetActive(true);
                return proj;
            }
        }

        // Optionally expand the pool if all projectiles are in use
        GameObject newProj = Instantiate(projectilePrefab);
        newProj.SetActive(false);
        newProj.transform.SetParent(transform);
        projectilePool.Add(newProj);
        newProj.SetActive(true);
        return newProj;
    }

    public void ReleaseProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
    }

}
