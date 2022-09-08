using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCategoryRepository repository = new SqlCategoryRepository();
            var result = repository.GetAll();
            foreach(var item in result)
                System.Console.WriteLine(item.Name);

        }
    }
}
