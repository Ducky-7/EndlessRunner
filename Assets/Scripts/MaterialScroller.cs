﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
	Material material;
	Vector2 offset;
	[SerializeField] bool alwaysScrolling = false;

	[Range(-10, 10)]
	public float xVelocity, yVelocity;

	private void OnValidate()
	{
		offset = new Vector2(xVelocity, yVelocity);
	}

	private void Awake()
	{
		material = GetComponent<Renderer>().material;
	}

	void Start()
	{
		offset = new Vector2(xVelocity, yVelocity);
	}

	void Update()
	{
		if(GameManager.Instance.gameState == GameState.Playing)
			material.mainTextureOffset += offset * Time.deltaTime;
		else if(alwaysScrolling)
			material.mainTextureOffset += offset * Time.deltaTime;
	}
}
