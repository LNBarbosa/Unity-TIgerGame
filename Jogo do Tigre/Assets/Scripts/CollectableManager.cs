using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Manages all collectables in the game as coins and bullets
 */
public class CollectableManager : MonoBehaviour {

    public int collectable;
	public int bullet;
	public Text GUIText;

    void Start() {
		this.collectable = 0;
        this.bullet = 10;
    }

    void Update() {
		// This is an example how to print text in the screen 
		// GUIText.text = "Jellys: " + this.collectable.ToString() + "/20\nKunai: " + this.bullet;
    }
}
