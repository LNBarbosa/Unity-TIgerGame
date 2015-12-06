using UnityEngine;
using System.Collections;

using UnityEngine.UI;

/**
 * It is what is going to be showing on the screen
 */
public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    void Update() {
        HeartUI.sprite = HeartSprites[player.currentHealth];
    }
}
