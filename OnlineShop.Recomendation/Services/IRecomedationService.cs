namespace OnlineShop.Recomendation.Services
{
    public interface IRecomedationService
    {
        public float GetRating(int userId, int productId);

        public Dictionary<int, float> GetRatings(int userId, List<int> productsId);
    }
}
