
using Godot;
using Godot.Collections;

public class Biom {

	public int radiation {set; get;} = 10;
	public int speedMultiplier {set; get;} = 1;
	public Vector2I atlasPosition {set; get;} = Vector2I.Zero;
	public string type {set; get;} = "forest";

	public string color {set; get;} = "000000";

	public Item[] res {set; get;}

	public Biom resources(params Item[] items) {
		res = items;
		return this;
	}
	
	public Biom add(){
		Bioms.bioms.Add(type, this);
		Bioms.biomsColor.Add(color, this);
		return this;
	}
}
