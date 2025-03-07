﻿using UnityEngine;
using UnityEngine.UI;

public class MaterialIcon : Text
{
	public string iconUnicode
	{
		get { return System.Convert.ToString(char.ConvertToUtf32(base.text, 0), 16); }
		set { base.text = char.ConvertFromUtf32(System.Convert.ToInt32(value, 16)); }
	}

	protected override void Start()
	{
		base.Start();
	}

	#if UNITY_EDITOR
	protected override void Reset()
	{
		base.Reset();
		iconUnicode = "e84d";
		base.font = null;
		base.color = new Color(0.196f, 0.196f, 0.196f, 1.000f);
		base.material = null;
		base.alignment = TextAnchor.MiddleCenter;
		base.supportRichText = false;
		base.horizontalOverflow = HorizontalWrapMode.Overflow;
		base.verticalOverflow = VerticalWrapMode.Overflow;
		base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));

		LoadFont();
	}

	/// <summary> Searches for the \"MaterialIcons-Regular\" font inside the project. </summary>
	public void LoadFont()
	{
		foreach(string guid in UnityEditor.AssetDatabase.FindAssets("MaterialIcons-Regular"))
		{
			string assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);

			if(assetPath.EndsWith(".ttf", System.StringComparison.OrdinalIgnoreCase) && System.IO.File.Exists(System.IO.Path.GetDirectoryName(assetPath) + "/codepoints"))
			{
				base.font = UnityEditor.AssetDatabase.LoadAssetAtPath<Font>(assetPath);
				break;
			}
		}
	}
	#endif

	#if UNITY_EDITOR
	protected override void OnValidate()
	{
		base.OnValidate();
		base.SetLayoutDirty();
	}
	#endif

	protected override void OnRectTransformDimensionsChange()
	{
		base.OnRectTransformDimensionsChange();
		base.fontSize = Mathf.FloorToInt(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height));
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);
	}

}