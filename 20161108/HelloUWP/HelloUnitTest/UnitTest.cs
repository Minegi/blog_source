using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HelloUWP.Model;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace HelloUnitTest
{
    [TestClass]
    public class JsonTest
    {
        private UserInfoList data_;

        [TestInitialize]
        public void Initialize()
        {
            Task<StorageFolder> getAssetFolderTask = Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets").AsTask();
            getAssetFolderTask.Wait();

            StorageFolder assetFolder = getAssetFolderTask.Result;

            Task<StorageFile> getJsonFileTask = assetFolder.GetFileAsync("MOCK_DATA.json").AsTask();
            getJsonFileTask.Wait();

            StorageFile jsonFile = getJsonFileTask.Result;

            Task<string> getJsonStringTask = FileIO.ReadTextAsync(jsonFile).AsTask();
            getJsonStringTask.Wait();

            string jsonString = getJsonStringTask.Result;

            data_ = JsonConvert.DeserializeObject<UserInfoList>(jsonString);
        }

        [TestMethod]
        public void DynamicLinqTest()
        {
            var query = data_.records.AsQueryable();
            var condition = "Id=1";
            //"id":1,"first_name":"Nancy","last_name":"Kelley","email":"nkelley0@mapy.cz","gender":"Female","ip_address":"145.64.248.83"
            var result = query.Where(condition);
            UserInfo user = result.First();

            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(user.FirstName, "Nancy");
            Assert.AreEqual(user.LastName, "Kelley");
            Assert.AreEqual(user.Email, "nkelley0@mapy.cz");
            Assert.AreEqual(user.Gender, "Female");
            Assert.AreEqual(user.IpAddress, "145.64.248.83");
        }
    }
}
