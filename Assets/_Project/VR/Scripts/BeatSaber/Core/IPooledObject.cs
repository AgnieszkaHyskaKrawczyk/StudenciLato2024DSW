namespace BeatSaber.Core
{
    public interface IPooledObject
    {
        public void Release(CubeColor color);
    }
}