using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;

    [SerializeField]
    private Player player;

    [SerializeField] Bala Prefab;
    [SerializeField] Target[] targetsPrefabs;

    List<I_pooler> targets = new List<I_pooler>();

    List<I_pooler> bullets = new List<I_pooler>();

    private void Awake()
    {
        instance = this;
    }

    public void RequestBullet(Transform _origin)
    {
        
        I_pooler selected;
        if (bullets.Count > 0)
        {
            selected = bullets[0];
            bullets.Remove(selected);
            (selected as Bala).gameObject.SetActive(true);
            (selected as Bala).limite(_origin);
        }
        else
        {
            selected = Instantiate(Prefab, _origin);
            (selected as Bala).limite(_origin);
        }
    }
    public void RequestTarget(Vector3 _origin)
    {
        int r = Random.Range(0, targetsPrefabs.Length);
        I_pooler selected;
        Target temp = targets.Find(x => (x as Target) == (targetsPrefabs[r] as Target)) as Target;
        if (temp != null)
        {
            selected = temp;
            targets.Remove(selected);
            (selected as Target).gameObject.SetActive(true);
            (selected as Target).transform.position = _origin;
            
        }
        else
        {
            selected = Instantiate(targetsPrefabs[r], _origin, Quaternion.identity);
            (selected as Target).inicializar(player);
        }
    }
    public void ReturnTargetToPool(I_pooler _item)
    {
        targets.Add(_item);
        _item.Ingresar();
        (_item as Target).gameObject.SetActive(false);
    }
    public void ReturnBulletToPool(I_pooler _item)
    {
        bullets.Add(_item);
        _item.Ingresar();
        (_item as Bala).gameObject.SetActive(false);
    }
}
