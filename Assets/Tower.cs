using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float range = 5f;
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        GameObject target = FindNearestEnemy();

        if (target != null && Time.time >= nextFireTime)
        {
            Shoot(target);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot(GameObject target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Vector2 direction = (target.transform.position - firePoint.position).normalized;
        Projectile projScript = projectile.GetComponent<Projectile>();
        projScript.direction = direction;
    }
    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }
}
