using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject feedback;
    Collider _collider;

    Animator _animator;
    [SerializeField]
    private float _destroyTime = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    public void Collect()
    {
        Instantiate(feedback,transform.position,transform.rotation);
        //Disable the collider
        _collider.enabled = false;
        _animator.SetTrigger("Collect");
        
        //Detroy the coin
        Invoke(nameof(DestoyOnAnimationComplete),_destroyTime);
    }

    private void DestoyOnAnimationComplete(){
        Destroy(gameObject);
    }
}
