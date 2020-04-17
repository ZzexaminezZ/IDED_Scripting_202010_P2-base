using UnityEngine;
using System;


[RequireComponent(typeof(Collider))]
public class Target : Entidad, I_pooler
{

    Rigidbody Bala_rigidbody;
    [SerializeField]
    private int maxHP = 1;

   
     Player player;

    private int currentHP;

    [SerializeField]
    private int scoreAdd = 10;

   
    
    public void  inicializar (Player _ref)
    {
        player = _ref;
    }
    private void Start()
    {
        currentHP = maxHP;
       
    }

    private void Awake()
    {
        Bala_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedObjectLayer = collision.gameObject.layer;

        if (collidedObjectLayer.Equals(Utils.PlayerLayer) ||
            collidedObjectLayer.Equals(Utils.KillVolumeLayer))
        {
            player.Daño();
            Pool.instance.ReturnTargetToPool(this);

        }
    }

    public override void Daño()
    {
        currentHP -= 1;
        if (currentHP <= 0)
        {
            player.SumarScore(scoreAdd);
            Pool.instance.ReturnTargetToPool(this);
        }
       
    }

    public void Ingresar()
    {
        currentHP = maxHP;
        Bala_rigidbody.velocity = Vector3.zero;
    }
}