using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent OnBallHitWall;
    public UnityEvent<int> OnGetCoin;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnBallHitWall.Invoke();
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            OnGetCoin.Invoke(coin.Value);
            coin.Collected();
            coin.SelfDestruct();
        }
    }
}
