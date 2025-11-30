using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI health;
    [SerializeField]
    private PlayerScript player;

    void Update()
    {
        health.text = player.health.ToString();
    }
}
