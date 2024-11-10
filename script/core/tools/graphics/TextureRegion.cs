using Godot;

public partial class TextureRegion : ImageTexture
    {
        public Vector2I atlasRegion;

        public TextureRegion() {
            atlasRegion = Vector2I.Zero;
        }

        public Vector2I getAtlasRegion(){
            return atlasRegion;
        }
	}