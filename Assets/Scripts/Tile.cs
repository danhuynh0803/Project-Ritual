using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject backgroundGO;
	public GameObject buildingGO;

	public Sprite[] buildings;

	public int column;
	public int row;
	public TileKinds tileKind;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(float length, int x, int y, TileKinds initialTileKind, GameObject parentGO) {
		column = x;
		row = y;
		tileKind = initialTileKind;

		this.gameObject.transform.SetParent(parentGO.transform);
		this.SetSize(length);
		Vector2 screenScale = this.GetComponent<RectTransform>().localScale;

		this.gameObject.transform.localPosition = new Vector3(x+0.5f, -y-0.5f, 1f) * length * screenScale.x;
		this.SetTileKind();
	}

	public void SetSize(float length) {
		RectTransform rectTransform = this.GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(length, length);
	}

	Color RandomGreenColor() {
		return new Color(Random.Range(0f, 0.5f), Random.Range(0.5f, 0.8f), Random.Range(0f, 0.4f));
	}

	void SetTileKind() {
		switch (tileKind) {
			case TileKinds.Castle:
				backgroundGO.GetComponent<Image>().color = this.RandomGreenColor();
				buildingGO.GetComponent<Image>().sprite = buildings[0];
				buildingGO.SetActive(true);
				break;
			case TileKinds.Hideout:
				backgroundGO.GetComponent<Image>().color = this.RandomGreenColor();
				buildingGO.GetComponent<Image>().sprite = buildings[1];
				buildingGO.SetActive(true);
				break;
			default:
				backgroundGO.GetComponent<Image>().color = this.RandomGreenColor();
				buildingGO.GetComponent<Image>().sprite = null;
				buildingGO.SetActive(false);
				break;
		}
	}

	public void ClickTile() {
		Debug.Log(column + "," + row + ": " + tileKind);
	}
}
