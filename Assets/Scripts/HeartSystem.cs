using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] private GameObject heart1, heart2, heart3;
    [SerializeField] private GameObject mana1, mana2, mana3;

    public void SetCurrentHealth(int playerHealth)
    {
        switch (playerHealth)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
        }
    }

    public void SetCurrentMana(int playerMana)
    {
        switch (playerMana)
        {
            case 3:
                mana1.SetActive(true);
                mana2.SetActive(true);
                mana3.SetActive(true);
                break;
            case 2:
                mana1.SetActive(true);
                mana2.SetActive(true);
                mana3.SetActive(false);
                break;
            case 1:
                mana1.SetActive(true);
                mana2.SetActive(false);
                mana3.SetActive(false);
                break;
            case 0:
                mana1.SetActive(false);
                mana2.SetActive(false);
                mana3.SetActive(false);
                break;
        }
    }
}
