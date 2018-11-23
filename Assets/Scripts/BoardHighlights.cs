﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour {
	public static BoardHighlights Instance {get;set;}

	public GameObject highlightPrefab;
	private List<GameObject> highlights;

	private void Start()
	{
		Instance = this;

		highlights = new List<GameObject>();	
	}

	private GameObject GetHighlightObject()
	{
		GameObject go = highlights.Find(g => !g.activeSelf);

		if (go == null)
		{
			go = Instantiate(highlightPrefab);
			highlights.Add(go);
		}

		return go;
	}

	public void HighlightAllowedMoves(bool[,] moves)
	{
		for(int i = 0; i < 15; i++)
		{
			for(int j = 0; j < 15; j++)
			{
				if (moves[i, j] == true)
				{
					GameObject go = GetHighlightObject();
					go.SetActive(true);
					go.transform.position = new Vector3(i+0.5f, 0.01f, j+0.5f);
				}
			}
		}
	}

	public void HideHighlights()
	{
		foreach(GameObject go in highlights)
			go.SetActive(false);
	}
}