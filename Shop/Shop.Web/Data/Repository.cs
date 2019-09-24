namespace Shop.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()//lista no instanciada de produc
        {
            return this.context.Products.OrderBy(p => p.Name);//por linq se ordena por el nombre lambda
                                                              //p puede ser cualquier cosa
        }

        public Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        public async Task<bool> SaveAllAsync()//hasta que no se ejecuta este metodo los pasados no sirven
        {                       //devulven true si los grabo en la base o false si no
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)//me devuelve verdadero si el id del producto existe
        {
            return this.context.Products.Any(p => p.Id == id);
        }
    }
}
