using UnityEngine;
using System.Collections;

public class FlockScript : MonoBehaviour
{
    public float radius = 40;
    public Vector3 center = new Vector3(178, 1122, 196);
    public float velocityScale = 1;

    public float sepRadius = 1;
    public float cohRadius = 10;
    
    Vector3 target;
    float expire = 6;
    float last;
    
	void Start ()
    {
        target = GetNewTarget();
        last = Time.realtimeSinceStartup;
	}

    Vector3 GetNewTarget()
    {
        last = Time.realtimeSinceStartup;
        return Random.insideUnitSphere * radius + center;
    }

	void Update ()
    {
        // if close to target, pick new target
        if ((transform.position - target).sqrMagnitude < 5 * 5)
            target = GetNewTarget();

        // it target expired, pick a new one
        if(Time.realtimeSinceStartup - last > expire)
            target = GetNewTarget();

        // save old rotation
        var oldrot = transform.rotation;

        transform.LookAt(target);
        transform.Rotate(-90, 0, 0);

        var newrot = transform.rotation;

        transform.rotation = Quaternion.Slerp(oldrot, newrot, 0.012f);
        transform.Translate(0, -velocityScale * Time.deltaTime, 0, Space.Self);

        foreach(Transform bird in transform.parent)
        {
            if (bird.name.IndexOf("bird") != 0)
                continue;

            float sqDist = (bird.transform.position - transform.position).sqrMagnitude;
            float vel = -velocityScale * Time.deltaTime;
            // outside of the cohesion radius
            if (sqDist > cohRadius)
            {
                vel *= 1.1f;

                oldrot = bird.transform.rotation;

                bird.transform.LookAt(transform);
                bird.transform.Rotate(-90, 0, 0);

                newrot = bird.transform.rotation;

                bird.transform.rotation = Quaternion.Slerp(oldrot, newrot, 0.03f);
                
            }
            // within cohesion radius
            else if (sqDist <= cohRadius && sqDist > sepRadius)
            {
                oldrot = bird.transform.rotation;
                newrot = transform.rotation;

                bird.transform.rotation = Quaternion.Slerp(oldrot, newrot, 0.012f);
            }
            // within separation radius
            foreach (Transform bird1 in transform.parent)
            {
                if (bird1 == bird || (bird.transform.position - bird1.transform.position).sqrMagnitude > sepRadius)
                    continue;

                oldrot = bird.transform.rotation;

                bird.transform.LookAt(transform);
                bird.transform.Rotate(-90, 180, 0);

                newrot = bird.transform.rotation;

                bird.transform.rotation = Quaternion.Slerp(oldrot, newrot, 0.012f);
            }

            bird.transform.Translate(0, vel, 0, Space.Self);
        }
    }
}
