using OnlineShop_Recomendation;

namespace OnlineShop.Recomendation.Services
{
    public class RecomedationService : IRecomedationService
    {
        public float GetRating(int userId, int productId)
        {

            //Load sample data
            var sampleData = new RecomendationMLModel.ModelInput()
            {
                UserId = userId,
                ProductId = productId,
            };

            //Load model and predict output
            var result = RecomendationMLModel.Predict(sampleData);

            float normalizedscore = Sigmoid(result.Score);

            return normalizedscore;
        }

        public Dictionary<int, float> GetRatings(int userId, List<int> productsId)
        {
            var productsRating = new Dictionary<int, float>();
            foreach (var productId in productsId)
            {
                var sampleData = new RecomendationMLModel.ModelInput()
                {
                    UserId = userId,
                    ProductId = productId,
                };

                //Load model and predict output
                var result = RecomendationMLModel.Predict(sampleData);
                var normalizedScore = Sigmoid(result.Score);

                productsRating.Add(productId, normalizedScore);
            }

            return productsRating;
        }

        private float Sigmoid(float x)
        {
            return (float)(100 / (1 + Math.Exp(-x)));
        }
    }
}
