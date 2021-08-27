namespace HourChallenge.Abstractions
{
    public interface IInputHandler
    {
        bool Touched { get; }
        bool SwipedUp { get; }
        bool SwipedDown { get; }
    }
}
