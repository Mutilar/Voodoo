
using System;
using UnityEngine;
public class numberedTerrain
{
	public int start, end, type;
	public float height, length;
	SpriteRenderer terrain;
	string direction, vegetationType;
	static int startCounter = 1, endCounter = 1;
	PolygonCollider2D collider;
	public numberedTerrain (int start, int end, int type, SpriteRenderer terrain)
	{
		this.start = start;
		this.end = end;
		this.type = type;
		this.terrain = terrain;
	}
	public numberedTerrain (float h, float l, int type, SpriteRenderer terrain, string dir, string vegTyp, PolygonCollider2D collider)
	{
		height = h;
		length = l;
		this.terrain = terrain;
		this.type = type;
		direction = dir;
		vegetationType = vegTyp;
		this.collider = collider;
	}
	public numberedTerrain (SpriteRenderer terrain)
	{
		this.terrain = terrain;
		this.start = startCounter;
		this.end = endCounter;
		this.type = 0;
	}
	public void assignVals (int start, int end, int type)
	{
		this.start = start;
		this.end = end;
		this.type = type;
	}
	public SpriteRenderer getTerrain ()
	{
		return terrain;
	}
	public bool checkVals (int start, int end, int type)
	{
		if (this.start == start && this.end == end && this.type == type)
			return true;
		return false;
	}
	public bool checkVals (string dir, string vegTyp)
	{
		if (dir.Equals (direction) && vegTyp.Equals (vegetationType))
			return true;
		return false;
	}
	public bool checkVals (string dir, string vegTyp, int typ)
	{
		if (dir.Equals (direction) && vegTyp.Equals (vegetationType) && typ.Equals (type))
			return true;
		return false;
	}
	public float getH ()
	{
		return height;
	}
	public PolygonCollider2D getCollider ()
	{
		return collider;
	}
	public float getL ()
	{
		return length;
	}
	public bool checkVals (int start, int end)
	{
		if (this.start == start && this.end == end)
			return true;
		return false;
	}
	public String toString ()
	{
		return start + " " + end + " " + type;
	}
}