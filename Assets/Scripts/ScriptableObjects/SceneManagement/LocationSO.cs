﻿using GeneralScriptableObjects.SceneData;
using UnityEngine;

/// <summary>
/// This class contains Settings specific to Locations only
/// </summary>

[CreateAssetMenu(fileName = "NewLocation", menuName = "Scene Data/Location")]
public class LocationSO : GameSceneSO
{
	public string locationName;
	public Sprite sceneImage;
}
