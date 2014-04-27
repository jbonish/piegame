#pragma strict

public var Sprite spriteList = [];
public var fps;
private var SpriteRenderer sprite_renderer;

function Start () {
	spriteRenderer = renderer as SpriteRenderer;
}

function Update () {
	int index = (int)(Time.timeSinceLevelLoad * fps);
	index = index % spriteList.Length;
	sprite_renderer.sprite = spriteList[index];
}