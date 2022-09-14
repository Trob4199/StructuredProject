namespace CKK.Logic.Repository.Interfaces
{
    internal interface IDataUnitOfWork
    {
        //public IShoppingCartRepository ShoppingCarts { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public ICustomerRepository Customers { get; }
    }
}
