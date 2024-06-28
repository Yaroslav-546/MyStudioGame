public interface IDataSaver
{
    public object TryLoad();

    public object Load();

    public void Save();
}

