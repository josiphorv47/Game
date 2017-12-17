using System;
using System.Runtime.Serialization.Formatters.Binary;

using GameLib.Systems.DAL;
using GameLib.Helpers;
using System.IO;

namespace GameLib.Systems.DAL.Repositories
{
    public class FileRepository : IRepository
    {
        private string fileLocation;

        public FileRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public DataFormat LoadData()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                return formatter.Deserialize(File.Open(fileLocation, FileMode.Open)) as DataFormat;
            }
            catch (Exception ex)
            {
                Error.LogAndPrint(ex);
                return null;
            }
        }

        public void SaveData(DataFormat data)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(File.Create(fileLocation), data);
            }
            catch (Exception ex)
            {
                Error.LogAndPrint(ex);
            }
        }
    }
}
