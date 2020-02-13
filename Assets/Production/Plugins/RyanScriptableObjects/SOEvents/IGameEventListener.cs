namespace Production.Plugins.RyanScriptableObjects.SOEvents {
    public interface IGameEventListener<T> {
        void OnEventRaised(T item);
    }
}