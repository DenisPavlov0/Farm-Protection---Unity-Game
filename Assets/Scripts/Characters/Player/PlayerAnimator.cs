using GameConstants;
using UnityEngine;
using static GameConstants.GlobalConst;


public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();  
    }
    public void PlayShootAnimation()
    {
        _animator.SetTrigger(Shoot);
    }
    public void OnShootAnimationEnd()
    {
        GetComponent<Shooting>().ShootBullet();
    }
}