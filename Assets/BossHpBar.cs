using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    [SerializeField] private Image hpBar;

    public float fill;
    void Start()
    {
        fill = 1f;
    }
    void Update()
    {
        hpBar.fillAmount = fill;
    }
}
