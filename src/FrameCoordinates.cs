using System.Collections.Generic;
using Godot;

namespace GoodAndEvil
{
    public class AnimationFrame
    {
        public string animationName;
        public List<FrameCoordinates> frames;
    }

    public class FrameCoordinates
    {
        public float x;
        public float y;

        public FrameCoordinates(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}