﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Core.BusinessLayer.Contracts;
using Store.Core.BusinessLayer.Responses;
using Store.Core.DataLayer;
using Store.Core.DataLayer.Repositories;
using Store.Core.EntityLayer.Production;

namespace Store.Core.BusinessLayer
{
    public class ProductionBusinessObject : BusinessObject, IProductionBusinessObject
    {
        public ProductionBusinessObject(ILogger logger, IUserInfo userInfo, StoreDbContext dbContext)
            : base(logger, userInfo, dbContext)
        {
        }

        public async Task<IPagingResponse<Product>> GetProductsAsync(Int32 pageSize = 10, Int32 pageNumber = 1, Int32? productCategoryID = null)
        {
            Logger?.LogInformation("{0} has been invoked", nameof(GetProductsAsync));

            var response = new PagingResponse<Product>();

            try
            {
                // Get query
                var query = ProductionRepository.GetProducts(productCategoryID);

                // Set information for paging
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;
                response.ItemsCount = await query.CountAsync();

                // Retrieve items, set model for response
                response.Model = await query.Paging(pageSize, pageNumber).ToListAsync();
            }
            catch (Exception ex)
            {
                response.SetError(ex, Logger);
            }

            return response;
        }

        public async Task<IPagingResponse<Warehouse>> GetWarehousesAsync(Int32 pageSize = 10, Int32 pageNumber = 1)
        {
            Logger?.LogInformation("{0} has been invoked", nameof(GetWarehousesAsync));

            var response = new PagingResponse<Warehouse>();

            try
            {
                // Get query
                var query = ProductionRepository.GetWarehouses();

                // Set information for paging
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;
                response.ItemsCount = await query.CountAsync();

                // Retrieve items, set model for response
                response.Model = await query.Paging(pageSize, pageNumber).ToListAsync();
            }
            catch (Exception ex)
            {
                response.SetError(ex, Logger);
            }

            return response;
        }
    }
}
