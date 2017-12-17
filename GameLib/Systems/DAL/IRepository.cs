namespace GameLib.Systems.DAL
{
    public interface IRepository
    {
        DataFormat LoadData();

        void SaveData(DataFormat data);
    }
}