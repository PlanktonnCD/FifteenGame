using Zenject;

namespace PlayerData
{
    public class DataManager
    {
        private HighScoreData _highScoreData = new HighScoreData();
        private DiContainer _container;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        public void SaveData()
        {
            DataController.SaveIntoJson(_highScoreData);
        }

        public void ReadData()
        {
            var data = DataController.ReadFromJson();
            if (data == null)
            {
                _highScoreData = new HighScoreData();
                _container.Inject(_highScoreData);
                return;
            }
            _highScoreData = data;
            _container.Inject(_highScoreData);
        }
    }
}