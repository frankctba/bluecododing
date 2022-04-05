namespace NewWebApi_1.WebApi.Services;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class TextFormatterFactory
{
    public static ITextFormatter CreateTextFormatter(string format)
    {
        if (string.IsNullOrEmpty(format))
            return new NoChangeFormatter();
        else if (format == "UpperCase")
            return new UpperCaseFormatter();
        else if (format == "LowerCase")
            return new LowerCaseFormatter();
        
        throw new InvalidOperationException("The parameter format does not correspond to any valid format!");
    }
}

public interface ITextFormatter
{
    IEnumerable<Food> ApplyFormat(IEnumerable<Food> foods);
}

public class NoChangeFormatter : ITextFormatter
{
    public IEnumerable<Food> ApplyFormat(IEnumerable<Food> foods)
    {
        return foods;
    }
}

public class UpperCaseFormatter : ITextFormatter
{
    public IEnumerable<Food> ApplyFormat(IEnumerable<Food> foods)
    {
        foreach (Food f in foods)
        {
            yield return string.IsNullOrEmpty(f.Name) ? f : new Food { Id = f.Id, Name = f.Name.ToUpper() };
        }
    }
}

public class LowerCaseFormatter : ITextFormatter
{
    public IEnumerable<Food> ApplyFormat(IEnumerable<Food> foods)
    {
        foreach (Food f in foods)
        {
            yield return string.IsNullOrEmpty(f.Name) ? f : new Food { Id = f.Id, Name = f.Name.ToLower() };
        }
    }
}

public interface IFoodService
{
    public IEnumerable<Food> GetAllFoods(string format);
}

public class FoodService : IFoodService
{
    private IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }
    
    public IEnumerable<Food> GetAllFoods(string format)
    {
        return TextFormatterFactory.CreateTextFormatter(format)
                    .ApplyFormat(_foodRepository.GetAllFoodsFromDb());
    }
}

public interface IFoodRepository
{
    public IEnumerable<Food> GetAllFoodsFromDb();
}

public class FoodRepository : IFoodRepository
{
    private static readonly Food[] _foods = new[]
    {
        new Food { Id = 1, Name = "Apple"}, 
        new Food { Id = 1, Name = "Tacco"}, 
        new Food { Id = 1, Name = "Pizza"}
    };

    public IEnumerable<Food> GetAllFoodsFromDb()
    {
        return _foods;
    }
}