namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 245;

        public MainCourse(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
