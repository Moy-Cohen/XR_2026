using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int currentCoins = 0;

    private void OnTriggerEnter(Collider other)
    {
        Coin possibleCoin = other.GetComponent<Coin>();

        if(possibleCoin != null){
            possibleCoin.Collect();
            currentCoins ++;
        }

        // if(other.TryGetComponent<Coin>(out Coin possiblecoin)){
        //     possibleCoin.Collect();
        //     currentCoins++;
        // }
    }

    private void OnGUI()
    {
        GUILayout.Label($"COINS:{currentCoins}");
    }
}
