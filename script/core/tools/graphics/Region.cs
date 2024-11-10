using Godot;

public class Region
    {
        public string Name { get; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public int AtlasPositionX { get; }
        public int AtlasPositionY { get; }

        public Region(string name, int x, int y, int width, int height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            AtlasPositionX = X / 64;
            AtlasPositionY = Y / 64;
        }

        public Rect2I Rectangle => new Rect2I(new Vector2I(X, Y), new Vector2I(Width, Height));

        public override string ToString()
        {
            return $"Region: {Name}, Position: ({X}, {Y}), AtlasPosition: ({AtlasPositionX}, {AtlasPositionY}), Size: ({Width}x{Height})";
        }
    }