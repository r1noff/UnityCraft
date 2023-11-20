namespace UnityCraft.Editor
{
    public interface ITool
    {
        bool IsRatchet { get; }
        
        string Name { get; }

        void HandleTurn(int delta);
    }
}