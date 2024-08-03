using MediatR;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Account;

namespace ParasutIntegration.Features
{
    public class RequestHandler
    {
    }

    //public class GetWarehousesQuery : IRequest<IParasutResponseModel<ParasutWarehouseModel>>, IRequestWithRoute
    //{
    //    public int id;

    //    public GetWarehousesQuery(int id = 0)
    //    {
    //        this.id = id;
    //    }

    //    public string GetRoute()
    //    {
    //        return RouteEnum.Warehouse.GetRouteString() + (id == 0 ? "" : $"/{id}");
    //    }

    //    public bool ShouldFetchAll()
    //    {
    //        return id == 0;
    //    }
    //}

    //public class GetProductsQuery : IRequest<IParasutResponseModel<ParasutProductModel>>, IRequestWithRoute
    //{
    //    public int id;

    //    public GetProductsQuery(int id = 0)
    //    {
    //        this.id = id;
    //    }

    //    public string GetRoute()
    //    {
    //        return RouteEnum.Product.GetRouteString() + (id == 0 ? "" : $"/{id}");
    //    }

    //    public bool ShouldFetchAll()
    //    {
    //        return id == 0;
    //    }
    //}

    //public class GetAccountsQuery : IRequest<IParasutResponseModel<AccountModel>>, IRequestWithRoute
    //{
    //    public int id;

    //    public GetAccountsQuery(int id = 0)
    //    {
    //        this.id = id;
    //    }

    //    public string GetRoute()
    //    {
    //        return RouteEnum.Product.GetRouteString() + (id == 0 ? "" : $"/{id}");
    //    }

    //    public bool ShouldFetchAll()
    //    {
    //        return id == 0;
    //    }
    //}
}
