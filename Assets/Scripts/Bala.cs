using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bala : MonoBehaviour, I_pooler
{

    Rigidbody Bala_rigidbody;
    [SerializeField] float bullerForce = 10;

   

    public void limite(Transform _origen)
    {
        Bala_rigidbody = GetComponent<Rigidbody>();
        transform.rotation = _origen.rotation;
        transform.position = _origen.position;
        Bala_rigidbody.velocity = Vector3.zero;
        Bala_rigidbody.AddForce(transform.up * bullerForce, ForceMode.Impulse);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.Daño();
            Pool.instance.ReturnBulletToPool(this);
        }

    }

    void I_pooler.Ingresar()
    {
        Bala_rigidbody.velocity = Vector3.zero;
    }

}
