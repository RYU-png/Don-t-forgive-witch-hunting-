using UnityEngine;

public class FadeImage : UnityEngine.UI.Graphic , IFade
{
	[SerializeField, Range (0, 1)]
	private float cutoutRange;

	public float Range {
		get {
			return cutoutRange;
		}
		set {
			cutoutRange = value;
			UpdateMaskCutout (cutoutRange);
		}
	}

	protected override void Start ()
	{
		base.Start ();
	}

	private void UpdateMaskCutout (float range)
	{
		enabled = true;
		material.SetFloat ("_Range", 1 - range);

		// レンジが0以下ならスクリプトを外す
		if (range <= 0) {
			this.enabled = false;
		}
	}

	// エディタ内で変更を加えた時に呼び出される関数
#if UNITY_EDITOR
	protected override void OnValidate ()
	{
		base.OnValidate ();
		UpdateMaskCutout (Range);

		// エディタ上での変更を更新→オーバーテクスチャの色を設定する
		material.SetColor("_TextureColor", color);
	}
#endif

	// オーバーテクスチャの色を設定する関数(外部からの変更に使用)
	public void SetColor(Color col)
    {
		color = col;
		material.SetColor("_TextureColor", color);
	}

	// トランジションに使用する画像を設定する関数
	public void SetMask(Texture texture)
    {
		material.SetTexture("_MaskTex", texture);
	}

	// トランジションの上に貼る画像を設定する関数
	public void SetOver(Texture texture)
	{
		material.SetFloat("_Mode", 1.0f);
		material.SetTexture("_OverTex", texture);
	}

	// トランジションの上を塗りつぶす色を設定する関数
	public void SetOver(Color color)
	{
		material.SetFloat("_Mode", -1.0f);
		material.SetColor("_OverColor", color);
	}
}