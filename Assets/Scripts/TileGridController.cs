using UnityEngine;
using System.Collections;


public enum TileKinds {
	Empty=0,
	Castle=1,
	Hideout=2,
}

public enum LevelKinds {
	Level1=1,
	Level2=2,
	Level3=3,
	Level4=4,
}

public class TileGridController : MonoBehaviour {

	public GameObject tilePrefab;
	public Tile[,] tiles;
	public GameObject tileGridParentGO;
	public LevelKinds currentLevel;

	// Use this for initialization
	void Start () {
		this.LoadMap(currentLevel);
	}

	public TileKinds GetTileKind(string tileCode) {
		switch (tileCode) {
			case "c":
				return TileKinds.Castle;
			case "h":
				return TileKinds.Hideout;
			default:
				return TileKinds.Empty;
		}
	}

	Tile[,] LoadMap(LevelKinds levelKind) {
		string[] mapData;
		switch (levelKind) {
			case LevelKinds.Level1:
				mapData = new string[2];
				mapData[0] = "x,x";
				mapData[1] = "x,c";
				break;
			case LevelKinds.Level2:
				mapData = new string[3];
				mapData[0] = "x,x,x";
				mapData[1] = "x,c,x";
				mapData[2] = "x,x,x";
				break;
			case LevelKinds.Level3:
				mapData = new string[4];
				mapData[0] = "x,x,x,x";
				mapData[1] = "x,c,x,x";
				mapData[2] = "x,x,x,x";
				mapData[3] = "x,x,x,x";
				break;
			case LevelKinds.Level4:
				mapData = new string[5];
				mapData[0] = "x,x,x,x,x";
				mapData[1] = "x,c,x,x,x";
				mapData[2] = "x,x,x,x,x";
				mapData[3] = "x,h,x,c,x";
				mapData[4] = "x,x,x,x,x";
				break;
			default:
				mapData = new string[1];
				mapData[0] = "x";
				break;
		}

		int rows = mapData.Length;
		int columns = mapData[0].Split(',').Length;
		float tileLength = Screen.height / rows;
		Tile[,] tiles = new Tile[columns, rows];

		for (int y=0; y<rows; y++) {
			string rowString = mapData[y];
			string[] columnCodes = rowString.Split(',');
			for (int x=0; x<columnCodes.Length; x++) {
				TileKinds tileKind = this.GetTileKind(columnCodes[x]);
				GameObject newTileGO = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity) as GameObject;
				Tile tile = newTileGO.GetComponent<Tile>();
				tile.Init(tileLength, x, y, tileKind, tileGridParentGO);
				tiles[x, y] = tile;
			}
		}

		return tiles;

	}
}
